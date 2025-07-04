﻿using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// https://www.pinvoke.net/default.aspx/kernel32.openprocess
// https://www.pinvoke.net/default.aspx/kernel32.virtualallocex

namespace CodeRedLauncher
{
    public enum ProcessFlags : UInt32
    {
        All = 0x001F0FFF,
        Terminate = 0x00000001,
        CreateThread = 0x00000002,
        VirtualMemoryOperation = 0x00000008,
        VirtualMemoryRead = 0x00000010,
        VirtualMemoryWrite = 0x00000020,
        DuplicateHandle = 0x00000040,
        CreateProcess = 0x000000080,
        SetQuota = 0x00000100,
        SetInformation = 0x00000200,
        QueryInformation = 0x00000400,
        QueryLimitedInformation = 0x00001000,
        Synchronize = 0x00100000
    }

    public enum AllocationType : UInt32
    {
        Commit = 0x1000,
        Reserve = 0x2000,
        Decommit = 0x4000,
        Release = 0x8000,
        Reset = 0x80000,
        Physical = 0x400000,
        TopDown = 0x100000,
        WriteWatch = 0x200000,
        LargePages = 0x20000000
    }

    public enum MemoryProtection : UInt32
    {
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        NoAccess = 0x01,
        ReadOnly = 0x02,
        ReadWrite = 0x04,
        WriteCopy = 0x08,
        GuardModifierflag = 0x100,
        NoCacheModifierflag = 0x200,
        WriteCombineModifierflag = 0x400
    }

    internal static class ProcessManager
    {
        [DllImport("ntdll.dll", PreserveSig = false)] public static extern void NtSuspendProcess(IntPtr processHandle);
        [DllImport("ntdll.dll", PreserveSig = false, SetLastError = true)] public static extern void NtResumeProcess(IntPtr processHandle);

        public static bool IsValidProcess(Process process)
        {
            try
            {
                if ((process != null)
                    && (process.Id > 8) // A process with an id of 8 or lower is a system process, we shouldn't be trying to access those.
                    && (process.MainWindowHandle != IntPtr.Zero)
                    && (process.Handle != IntPtr.Zero))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Logger.Write("(IsValidProcess) Exception: " + ex.ToString(), LogLevel.Warning); // Most likely an access denied exception which is fine, can also happen if the process is brand new.
            }

            return false;
        }

        public static List<ProcessModule> GetModules(Process process)
        {
            List<ProcessModule> returnList = new List<ProcessModule>();

            if (IsValidProcess(process))
            {
                try
                {
                    foreach (ProcessModule module in process.Modules)
                    {
                        if ((module != null) && (module.BaseAddress != IntPtr.Zero))
                        {
                            returnList.Add(module);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write("(GetModules) Exception: " + ex.ToString(), LogLevel.Warning);
                }
            }

            return returnList;
        }

        public static List<Process> GetAllProcesses()
        {
            List<Process> returnList = new List<Process>();
            Process[] processList = Process.GetProcesses();

            foreach (Process process in processList)
            {
                if (IsValidProcess(process))
                {
                    returnList.Add(process);
                }
            }

            return returnList;
        }

        public static Process? GetProcess(Int32 pid)
        {
            Process[] processList = Process.GetProcesses();

            foreach (Process process in processList)
            {
                if (process.Id == pid)
                {
                    return process;
                }
            }

            return null;
        }

        public static List<Process> GetFilteredProcesses(string filter)
        {
            List<Process> returnList = new List<Process>();
            Process[] processList = Process.GetProcessesByName(filter);

            foreach (Process process in processList)
            {
                if (IsValidProcess(process))
                {
                    if (process.ProcessName.Contains(filter) || process.MainWindowTitle.Contains(filter))
                    {
                        returnList.Add(process);
                    }
                }
            }

            return returnList;
        }

        public static bool CloseProcesses()
        {
            List<Process> runningProcesses = GetFilteredProcesses(LibraryManager.Settings.ProcessName);

            foreach (Process process in runningProcesses)
            {
                if (IsValidProcess(process))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception ex)
                    {
                        Logger.Write("(CloseProcesses) Exception: " + ex.ToString(), LogLevel.Warning);
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public enum InjectionResults : byte
    {
        None,
        UnhandledException,
        LibraryNotFound,
        ProcessNotFound,
        AlreadyInjected,
        HandleNotFound,
        KernalNotFound,
        AllocateFail,
        WriteFail,
        ThreadFail,  
        Success
    }

    public static class LibraryManager
    {
        private static List<IntPtr> m_handleCache = new List<IntPtr>(); // Handle cache for processes we've already loaded into.

        public static class Settings
        {
            public static readonly string ModuleName = "CodeRed.dll";
            public static readonly string ProcessName = "RocketLeague";
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, UInt32 size, Int32 lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
        IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, UInt32 flAllocationType, UInt32 flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern Int32 CloseHandle(IntPtr hObject);

        public static bool IsModuleLoaded(Process process, bool bForceCheck)
        {
            if (ProcessManager.IsValidProcess(process))
            {
                if (bForceCheck)
                {
                    List<ProcessModule> moudles = ProcessManager.GetModules(process);

                    foreach (ProcessModule module in moudles)
                    {
                        try
                        {
                            if (module.FileName.Contains(Settings.ModuleName))
                            {
                                if (!m_handleCache.Contains(process.Handle))
                                {
                                    m_handleCache.Add(process.Handle);
                                }

                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Write("(IsModuleLoaded) Exception: " + ex.ToString(), LogLevel.Warning);
                        }
                    }
                }
                else
                {
                    return m_handleCache.Contains(process.Handle);
                }
            }

            return false;
        }

        public static bool AnyProcessRunning()
        {
            if (ProcessManager.GetFilteredProcesses(Settings.ProcessName).Count > 0)
            {
                return true;
            }

            m_handleCache.Clear(); // If there aren't any processes running, might as well clear the handle cache here while we're at it.
            return false;
        }

        // Attempts to dynamically load a library into all found processes (if configured as such), as well as update/clean up the "m_handleCache" list.
        public static List<InjectionResults> TryLoadDynamic(Architecture.Path libraryFile)
        {
            List<InjectionResults> returnList = new List<InjectionResults>();
            List<Process> processes = ProcessManager.GetFilteredProcesses(Settings.ProcessName);

            if (processes.Count > 0)
            {
                List<IntPtr> injectedHandles = new List<IntPtr>();

                if (!libraryFile.Exists())
                {
                    returnList.Add(InjectionResults.LibraryNotFound);
                    return returnList;
                }

                for (Int32 i = 0; i < processes.Count; i++)
                {
                    InjectionResults individualResult = InjectionResults.None;

                    if (i == 0)
                    {
                        individualResult = TryLoadIndividual(processes[0], libraryFile);
                        returnList.Add(individualResult);

                        if (individualResult == InjectionResults.Success)
                        {
                            injectedHandles.Add(processes[0].Handle);
                        }

                        if (!Configuration.ShouldInjectAll())
                        {
                            return returnList;
                        }
                    }
                    else if (Configuration.ShouldInjectAll())
                    {
                        individualResult = TryLoadIndividual(processes[i], libraryFile);
                        returnList.Add(individualResult);

                        if (individualResult == InjectionResults.Success)
                        {
                            injectedHandles.Add(processes[i].Handle);
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // If our cache doesn't include the processes we've just injected into, the process closed and is no longer injected.
                foreach (IntPtr handle in injectedHandles)
                {
                    if (!m_handleCache.Contains(handle))
                    {
                        m_handleCache.Remove(handle);
                    }
                }
            }
            else
            {
                m_handleCache.Clear();
                returnList.Add(InjectionResults.ProcessNotFound);
            }

            return returnList;
        }

        // Attempts to load a library into an individual process, adds to the "m_handleCache" list but does NOT remove old handles.
        public static InjectionResults TryLoadIndividual(Process process, Architecture.Path libraryFile)
        {
            if (libraryFile.Exists())
            {
                if (ProcessManager.IsValidProcess(process))
                {
                    if (!IsModuleLoaded(process, false))
                    {
                        InjectionResults result = LoadLibraryInternal(process, libraryFile);

                        if (result == InjectionResults.Success)
                        {
                            m_handleCache.Add(process.Handle);
                        }

                        return result;
                    }
                    else
                    {
                        return InjectionResults.AlreadyInjected;
                    }
                }
                else
                {
                    m_handleCache.Clear();
                    return InjectionResults.ProcessNotFound;
                }
            }

            return InjectionResults.LibraryNotFound;
        }

        private static InjectionResults LoadLibraryInternal(Process process, Architecture.Path libraryFile)
        {
            try
            {
                IntPtr processHandle = OpenProcess(Convert.ToUInt32(ProcessFlags.All), 1, Convert.ToUInt32(process.Id));

                if (processHandle == IntPtr.Zero)
                {
                    return InjectionResults.HandleNotFound;
                }

                IntPtr loadLibraryAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

                if (loadLibraryAddress == IntPtr.Zero)
                {
                    CloseHandle(processHandle);
                    return InjectionResults.KernalNotFound;
                }

                IntPtr allocatedAddress = VirtualAllocEx(processHandle, IntPtr.Zero, new IntPtr(libraryFile.GetPath().Length), (Convert.ToUInt32(AllocationType.Commit) | Convert.ToUInt32(AllocationType.Reserve)), Convert.ToUInt32(MemoryProtection.ExecuteReadWrite));

                if (allocatedAddress == IntPtr.Zero)
                {
                    CloseHandle(processHandle);
                    return InjectionResults.AllocateFail;
                }

                byte[] bytes = Encoding.ASCII.GetBytes(libraryFile.GetPath());
                int bWroteMemory = WriteProcessMemory(processHandle, allocatedAddress, bytes, Convert.ToUInt32(bytes.Length), 0);

                if (bWroteMemory == 0)
                {
                    CloseHandle(processHandle);
                    return InjectionResults.WriteFail;
                }

                IntPtr threadHandle = CreateRemoteThread(processHandle, IntPtr.Zero, IntPtr.Zero, loadLibraryAddress, allocatedAddress, 0, IntPtr.Zero);

                if (threadHandle == IntPtr.Zero)
                {
                    CloseHandle(processHandle);
                    return InjectionResults.ThreadFail;
                }

                CloseHandle(threadHandle);
                CloseHandle(processHandle);

                return InjectionResults.Success;
            }
            catch (Exception ex)
            {
                Logger.Write("(LoadLibraryInternal) Exception: " + ex.ToString(), LogLevel.Error); // Something went terribly wrong if this happens, will definitely want to know the exception reason.
            }

            return InjectionResults.UnhandledException;
        }
    }
}