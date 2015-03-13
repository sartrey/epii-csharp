using System;
using System.Drawing;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class ToolStripTextBoxEx : ToolStripTextBox
    {
        public override Size GetPreferredSize(Size constrainingSize)
        {
            if (IsOnOverflow || Owner.Orientation == Orientation.Vertical)
                return DefaultSize;
            var width = Owner.DisplayRectangle.Width;
            if (Owner.OverflowButton.Visible)
            {
                width = width - Owner.OverflowButton.Width -
                    Owner.OverflowButton.Margin.Horizontal;
            }
            var ex_count = 0;
            foreach (ToolStripItem item in Owner.Items)
            {
                if (item.IsOnOverflow) continue;
                if (item is ToolStripTextBoxEx)
                {
                    ex_count++;
                    width -= item.Margin.Horizontal;
                }
                else
                {
                    width = width - item.Width - item.Margin.Horizontal;
                }
            }
            if (ex_count > 1) 
                width /= ex_count;
            if (width < DefaultSize.Width) 
                width = DefaultSize.Width;
            Size size = base.GetPreferredSize(constrainingSize);
            size.Width = width;
            return size;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            SelectAll();
            Focus();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if(Focused)
                Owner.Focus();
            base.OnMouseLeave(e);
        }
    }
}
