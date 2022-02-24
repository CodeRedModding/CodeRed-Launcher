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
        // To Do: Not this class get rid of it I hate it but it works so maybe like don't get rid of it??
        private static class StringDictonary
        {
            // I have zero shame in this.
            private static readonly char[] AlphabetChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            private static readonly char[] DecimalChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            private static readonly char[] HexadecimalChars = { 'A', 'B', 'C', 'D', 'E', 'F' };

            public static bool IsCharAlphabet(char c)
            {
                return AlphabetChars.Contains(c.ToString().ToUpper()[0]);
            }

            public static bool IsCharDecimal(char c)
            {
                return DecimalChars.Contains(c.ToString().ToUpper()[0]);
            }

            public static bool IsCharHexadecimal(char c)
            {
                if (HexadecimalChars.Contains(c.ToString().ToUpper()[0]))
                {
                    return true;
                }

                return IsCharDecimal(c);
            }
        }

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
                    if (StringDictonary.IsCharAlphabet(c) || StringDictonary.IsCharDecimal(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_ALPHABET_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (StringDictonary.IsCharAlphabet(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_DECIMAL_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (StringDictonary.IsCharDecimal(c))
                    {
                        filteredText += c;
                    }
                }
            }
            else if (Filter == FilterTypes.TYPE_HEXADECIMAL_ONLY)
            {
                foreach (char c in inputText)
                {
                    if (StringDictonary.IsCharHexadecimal(c))
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
