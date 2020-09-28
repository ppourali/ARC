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
    public partial class DateMaskedTextbox : MaskedTextBox
    {
        public DateMaskedTextbox()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

        }

        //protected override void OnEnter(EventArgs e)
        //{
        //    //base.BackColor = Color.Yellow;
        //    //base.Focus();
        //    //base.SelectAll();
        //    base.OnEnter(e);
        //}

        //protected override void OnLeave(EventArgs e)
        //{
        //    //base.BackColor = Color.White;
        //    base.OnLeave(e);
        //}


        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
                e.Handled = true;
                TopLevelControl.SelectNextControl(this, true, true, true, true);

            }
            else
                base.OnKeyDown(e);
        }

        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        SendKeys.Send("{TAB}");
        //        return true;
        //        //Parent.SelectNextControl(this, true, true, true, true);

        //    }
        //    return base.ProcessDialogKey(keyData);
        //}
    }
}
