﻿using System;

using System.Globalization;

using System.Windows.Forms;

namespace HDC {
    public partial class NumericTextBox : TextBox { // Apparently I have to create my own control for a fool proof number box.
        bool allowSpace = false;
        protected override void OnKeyPress(KeyPressEventArgs e) {
            base.OnKeyPress(e);
            NumberFormatInfo numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar)) { //digits, and backspace are all valid input
            } else if (e.KeyChar == '\b') {
            } else if (this.allowSpace && e.KeyChar == ' ') {
            } else {
                e.Handled = true;
            }
        }

        public int IntValue {
            get {
                return Int32.Parse(this.Text);
            }
        }

        public decimal DecimalValue {
            get {
                return Decimal.Parse(this.Text);
            }
        }

        public bool AllowSpace {
            set {
                this.allowSpace = value;
            }

            get {
                return this.allowSpace;
            }
        }
    }
}
