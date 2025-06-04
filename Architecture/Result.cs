using System;

namespace CodeRedLauncher
{
    // Storage class used to report if tasks have failed or not, along with optional details regarding why it either failed or succeeded.
    public class Result
    {
        public bool Succeeded { get; set; } = false;
        public string FailReason { get; set; } = "";

        public bool HasFailReason()
        {
            return !string.IsNullOrEmpty(FailReason);
        }
    }
}
