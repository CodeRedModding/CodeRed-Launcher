using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRedLauncher
{
    public enum UpdatorStatus : byte
    {
        STATUS_IDLE,
        STATUS_INJECTOR,
        STATUS_MODULE
    }

    public static class Updator
    {
        public static UpdatorStatus Status { get; set; } = UpdatorStatus.STATUS_IDLE;
        public static bool IsOutdated { get; set; } = false;
    }
}
