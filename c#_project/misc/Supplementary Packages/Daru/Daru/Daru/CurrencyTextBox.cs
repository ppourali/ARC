using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Daru
{
    public partial class CurrencyTextBox : TextBox
    {
        public CurrencyTextBox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.BackColor = Color.Yellow;
            base.Focus();
            base.SelectAll(); 
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.BackColor = Color.White;
            base.OnLeave(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (base.TextLength > 0)
            {
                base.Text = long.Parse(base.Text.Replace(",", "")).ToString("N0");
            }
            else if (base.Text.Length == 0)
            {
                base.Text = "0";
            }

            base.Select(base.TextLength, 1);

            base.OnTextChanged(e);
        }

        public override string Text
        {
            get
            {
                return base.Text.Replace(",", "");
            }
            set
            {
                base.Text = value;
            }
        }
    }
}
