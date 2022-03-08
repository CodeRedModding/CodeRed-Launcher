using System;

namespace CodeRedLauncher
{
    // Storage class used to report if tasks have failed or not, along with optional details regarding why it either failed or succeeded.
    public class Report
    {
        public bool Succeeded { get; set; }
        public string? FailReason { get; set; }

        public Report()
        {
            Succeeded = false;
            FailReason = null;
        }

        public Report(bool bSucceeded, string failReason = null)
        {
            Succeeded = bSucceeded;
            FailReason = failReason;
        }
        
        bool HasFailReason()
        {
            return (FailReason != null);
        }
    }
}
