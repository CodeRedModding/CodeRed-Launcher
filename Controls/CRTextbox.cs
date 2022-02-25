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

        public string DisplayText
        {
            get { return InputBx.Text; }
            set { InputBx.Text = value; }
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
                    if (Extensions.StringDictonary.IsCharAlphabet(c) || Extensions.StringDictonary.IsCharDecimal(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_ALPHABET_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (Extensions.StringDictonary.IsCharAlphabet(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_DECIMAL_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (Extensions.StringDictonary.IsCharDecimal(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_HEXADECIMAL_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (Extensions.StringDictonary.IsCharHexadecimal(c))
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
            CRTextbox_TextChanged(e);
        }

        public event EventHandler TextChangedEvent;
        protected void CRTextbox_TextChanged(EventArgs e)
        {
            TextChangedEvent?.Invoke(this, e);
        }
    }
}
