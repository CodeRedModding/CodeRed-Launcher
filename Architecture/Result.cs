﻿using System;

namespace CodeRedLauncher
{
    // Storage class used to report if tasks have failed or not, along with optional details regarding why it either failed or succeeded.
    public class Result
    {
        public bool Succeeded { get; set; }
        public string? FailReason { get; set; }

        public Result()
        {
            Succeeded = false;
            FailReason = null;
        }

        public Result(bool bSucceeded, string? failReason = null)
        {
            Succeeded = bSucceeded;
            FailReason = failReason;
        }

        public bool HasFailReason()
        {
            return !string.IsNullOrEmpty(FailReason);
        }
    }
}
