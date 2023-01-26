using System;
using System.Drawing;
using System.Windows.Forms;

namespace CodeRedLauncher.Controls
{
    public partial class CRTextbox : UserControl
    {
        public enum FilterTypes : byte
        {
            TYPE_NONE,
            TYPE_NO_SYMBOLS,
            TYPE_ALPHABET_ONLY,
            TYPE_DECIMAL_ONLY,
            TYPE_HEXADECIMAL_ONLY
        }

        private FilterTypes Filter = FilterTypes.TYPE_NONE;

        public FilterTypes TextFilter
        {
            get { return Filter;  }
            set { Filter = value; }
        }

        public Font DisplayFont
        {
            get { return InputBx.Font; }
            set { InputBx.Font = value; }
        }

        public string DisplayText
        {
            get { return InputBx.Text; }
            set { InputBx.Text = value; }
        }

        public bool ReadOnly
        {
            get { return InputBx.ReadOnly; }
            set { InputBx.ReadOnly = value; }
        }

        public CRTextbox()
        {
            InitializeComponent();
        }

        private string FilterText(string inputText)
        {
            string filteredText = "";

            if (Filter == FilterTypes.TYPE_NO_SYMBOLS)
            {
                foreach (char c in inputText)
                {
                    if (Extensions.Strings.IsCharAlphabet(c) || Extensions.Strings.IsCharDecimal(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_ALPHABET_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (Extensions.Strings.IsCharAlphabet(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_DECIMAL_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (Extensions.Strings.IsCharDecimal(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_HEXADECIMAL_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (Extensions.Strings.IsCharHexadecimal(c))
                    {
                        filteredText += c;
                    }
                }
            }

            return filteredText;
        }

        private void InputBx_TextChanged(object sender, EventArgs e)
        {
            if (Filter != FilterTypes.TYPE_NONE)
            {
                DisplayText = FilterText(InputBx.Text);
            }

            base.OnTextChanged(e);
            CRTextbox_InputChanged(e);
        }

        public event EventHandler OnInputChanged;
        protected void CRTextbox_InputChanged(EventArgs e)
        {
            OnInputChanged?.Invoke(this, e);
        }

        private void CRTextbox_SizeChanged(object sender, EventArgs e)
        {
            InputBx.Location = new Point(InputBx.Location.X, (BackgroundPnl.Height / 2) - (Int32)InputBx.Font.Size);
            Invalidate();
        }
    }
}
