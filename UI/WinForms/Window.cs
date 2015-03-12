using System;
using System.Drawing;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class Window : Form
    {
        protected bool _IsSizeLocked = true;
        protected Size _LockSize;

        public bool IsSizeLocked
        {
            get { return _IsSizeLocked; }
            set { _IsSizeLocked = value; }
        }

        public View View
        {
            get { return Controls.Count > 0 ? Controls[0] as View : null; }
            set
            {
                var view = View;
                if (view == value)
                    return;
                if (view != null) {
                    Controls.Clear();
                    view.Dispose();
                }
                if (value != null) {
                    _LockSize = ClientSize = value.Size;
                    value.Dock = DockStyle.Fill;
                    Controls.Add(value);
                }
            }
        }

        public Window(View view)
        {
            View = view;
        }

        public void FinishDialog(DialogResult result)
        {
            this.DialogResult = result;
            this.Close();
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            if (_IsSizeLocked)
                ClientSize = _LockSize;
            base.OnResizeEnd(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                var view = View;
                if (view != null)
                    view.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}