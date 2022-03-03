using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodeRedLauncher
{
    public static class Sessions
    {
        public static Architecture.Range32 Timeframe = new Architecture.Range32(0, 30); // Current day, to thirty days back.
    }
}