using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRCountdown : UserControl
    {
        public Int32 Value
        {
            get { return Int32.Parse(TimerLbl.Text); }
            set { TimerLbl.Text = value.ToString(); }
        }

        public CRCountdown()
        {
            InitializeComponent();
        }
    }
}
