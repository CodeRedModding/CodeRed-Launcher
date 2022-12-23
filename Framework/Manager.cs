using System;
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

    public enum ThreadFlags : UInt32
    {
        TERMINATE = 0x0001,
        SUSPEND_RESUME = 0x0002,
        GET_CONTEXT = 0x0008,
        SET_CONTEXT = 0x0010,
        SET_INFORMATION = 0x0020,
        QUERY_INFORMATION = 0x0040,
        SET_THREAD_TOKEN = 0x0080,
        IMPERSONATE = 0x0100,
        DIRECT_IMPERSONATION = 0x0200
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
            if (process != null
                && process.Id > 8 // A process with an id of 8 or lower is a system process, we shouldn't be trying to access those.
                && process.MainWindowHandle != IntPtr.Zero)
            {
                return true;
            }

            return false;
        }

        public static List<ProcessModule> GetModules(Process process)
        {
            List<ProcessModule> returnList = new List<ProcessModule>();

            if (IsValidProcess(process))
            {
                foreach (ProcessModule module in process.Modules)
                {
                    if (module != null && module.BaseAddress != IntPtr.Zero)
                    {
                        returnList.Add(module);
                    }
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
            List<Process> runningProcesses = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

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
                        Logger.Write("Exception when trying to close process: " + ex.ToString());
                        return false;
                    }
                }
            }

            return true;
        }

        public static void Suspend(Process process)
        {
            if (IsValidProcess(process))
            {
                NtSuspendProcess(process.Handle);
            }
        }

        public static void Resume(Process process)
        {
            if (IsValidProcess(process))
            {
                NtResumeProcess(process.Handle);
            }
        }
    }

    public enum InjectionResults : byte
    {
        RESULT_NONE,
        RESULT_LIBRARY_NOT_FOUND,
        RESULT_PROCESS_NOT_FOUND,
        RESULT_RETRY_INJECTION,
        RESULT_ALREADY_INJECTED,
        RESULT_HANDLE_NOT_FOUND,
        RESULT_KERNAL_NOT_FOUND,
        RESULT_ALLOCATE_FAIL,
        RESULT_WRITE_FAILT,
        RESULT_THREAD_FAIL,  
        RESULT_SUCCESS
    }

    public static class LibraryManager
    {
        private static List<IntPtr> CachedHandles = new List<IntPtr>(); // Handle cache for processes we've already loaded into.

        public static class Settings
        {
            public static readonly string ModuleName = "CodeRed.dll";
            public static readonly string ProcessName = "RocketLeague";
            public static readonly string WindowTitle = "Rocket League (64-bit, DX11, Cooked)";
            public static readonly string RetryKeyword = "Not Responding"; // Not currently implemented as it's not needed at the moment.
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
                        if (module.FileName.Contains(Settings.ModuleName))
                        {
                            if (!CachedHandles.Contains(process.Handle))
                            {
                                CachedHandles.Add(process.Handle);
                            }

                            return true;
                        }
                    }
                }
                else
                {
                    return CachedHandles.Contains(process.Handle);
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

            CachedHandles.Clear(); // If there aren't any processes running, might as well clear the handle cache here while we're at it.
            return false;
        }

        // Attempts to dynamically load a library into all found processes (if configured as such), as well as update/clean up the "CachedHandles" list.
        public static List<InjectionResults> TryLoadDynamic(Architecture.Path libraryFile)
        {
            List<InjectionResults> returnList = new List<InjectionResults>();
            List<Process> processes = ProcessManager.GetFilteredProcesses(Settings.ProcessName);

            if (processes.Count > 0)
            {
                List<IntPtr> injectedHandles = new List<IntPtr>();

                if (!libraryFile.Exists())
                {
                    returnList.Add(InjectionResults.RESULT_LIBRARY_NOT_FOUND);
                    return returnList;
                }

                for (Int32 i = 0; i < processes.Count; i++)
                {
                    InjectionResults individualResult = InjectionResults.RESULT_NONE;

                    if (i == 0)
                    {
                        individualResult = TryLoadIndividual(processes[0], libraryFile);
                        returnList.Add(individualResult);

                        if (individualResult == InjectionResults.RESULT_SUCCESS)
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

                        if (individualResult == InjectionResults.RESULT_SUCCESS)
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
                    if (!CachedHandles.Contains(handle))
                    {
                        CachedHandles.Remove(handle);
                    }
                }
            }
            else
            {
                CachedHandles.Clear();
                returnList.Add(InjectionResults.RESULT_PROCESS_NOT_FOUND);
            }

            return returnList;
        }

        // Attempts to load a library into an individual process, adds to the "CachedHandles" list but does NOT remove old handles.
        public static InjectionResults TryLoadIndividual(Process process, Architecture.Path libraryFile)
        {
            if (libraryFile.Exists())
            {
                if (ProcessManager.IsValidProcess(process))
                {
                    if (!IsModuleLoaded(process, false))
                    {
                        InjectionResults result = LoadLibraryInternal(process, libraryFile);

                        if (result == InjectionResults.RESULT_SUCCESS)
                        {
                            CachedHandles.Add(process.Handle);
                        }

                        return result;
                    }
                    else
                    {
                        return InjectionResults.RESULT_ALREADY_INJECTED;
                    }
                }
                else
                {
                    return InjectionResults.RESULT_PROCESS_NOT_FOUND;
                }
            }

            return InjectionResults.RESULT_LIBRARY_NOT_FOUND;
        }

        private static InjectionResults LoadLibraryInternal(Process process, Architecture.Path libraryFile)
        {
            IntPtr processHandle = OpenProcess(Convert.ToUInt32(ProcessFlags.All), 1, Convert.ToUInt32(process.Id));

            if (processHandle == IntPtr.Zero)
            {
                return InjectionResults.RESULT_HANDLE_NOT_FOUND;
            }

            IntPtr loadLibraryAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            if (loadLibraryAddress == IntPtr.Zero)
            {
                CloseHandle(processHandle);
                return InjectionResults.RESULT_KERNAL_NOT_FOUND;
            }

            IntPtr allocatedAddress = VirtualAllocEx(processHandle, IntPtr.Zero, new IntPtr(libraryFile.GetPath().Length), Convert.ToUInt32(AllocationType.Commit) | Convert.ToUInt32(AllocationType.Reserve), Convert.ToUInt32(MemoryProtection.ExecuteReadWrite));

            if (allocatedAddress == IntPtr.Zero)
            {
                CloseHandle(processHandle);
                return InjectionResults.RESULT_ALLOCATE_FAIL;
            }

            byte[] bytes = Encoding.ASCII.GetBytes(libraryFile.GetPath());
            int bWroteMemory = WriteProcessMemory(processHandle, allocatedAddress, bytes, Convert.ToUInt32(bytes.Length), 0);

            if (bWroteMemory == 0)
            {
                CloseHandle(processHandle);
                return InjectionResults.RESULT_WRITE_FAILT;
            }

            IntPtr threadHandle = CreateRemoteThread(processHandle, IntPtr.Zero, IntPtr.Zero, loadLibraryAddress, allocatedAddress, 0, IntPtr.Zero);

            if (threadHandle == IntPtr.Zero)
            {
                CloseHandle(processHandle);
                return InjectionResults.RESULT_THREAD_FAIL;
            }

            CloseHandle(threadHandle);
            CloseHandle(processHandle);

            return InjectionResults.RESULT_SUCCESS;
        }
    }
}
