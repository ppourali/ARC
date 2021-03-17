using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mehr
{
    public partial class IDTextBox : TextBox
    {
        public IDTextBox()
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

        

        //protected override void OnTextChanged(EventArgs e)
        //{
        //    if (base.TextLength > 0)
        //    {
        //        base.Text = long.Parse(base.Text.Replace(",", "")).ToString("N0");
        //    }

        //    base.Select(base.TextLength, 1);

        //    base.OnTextChanged(e);
        //}

        //public override string Text
        //{
        //    get
        //    {
        //        return base.Text.Replace(",", "");
        //    }
        //    set
        //    {
        //        base.Text = value;
        //    }
        //}

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            if (base.Text.Trim() != "")
                //txtid.Text = string.Format("{0:0000}",txtid.Text);
                base.Text = base.Text.PadLeft(15, '0');
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & !e.KeyChar.Equals('-'))
            {
                e.Handled = true;
            }
        }

       
    }
}
