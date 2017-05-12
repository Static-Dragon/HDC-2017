using System;

using System.Globalization;

using System.Windows.Forms;

namespace HDC {
    public partial class NumericTextBox : TextBox { // Apparently I have to create my own control for a fool proof number box. (modified for port, removed support for spaces and decimal)

        protected override void OnKeyPress(KeyPressEventArgs e) {
            base.OnKeyPress(e);
            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar)) { //digits, and backspace are all valid input
            } else if (e.KeyChar == '\b') {
            } else {
                e.Handled = true;
            }
        }

        public int IntValue {
            get { return Int32.Parse(this.Text); }
        }

    }
}
