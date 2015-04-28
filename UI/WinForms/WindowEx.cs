using System;
using System.Drawing;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class WindowEx : Form
    {
        protected bool _IsSizeLocked = true;
        protected Size _LockSize;

        public bool IsSizeLocked
        {
            get { return _IsSizeLocked; }
            set { _IsSizeLocked = value; }
        }

        public WindowEx(View view)
        {
            SetView(view);
            StartPosition = FormStartPosition.CenterScreen;
        }

        protected void CopyStyle(View view) 
        {
            Text = view.Text;
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
                var view = GetView();
                if (view != null)
                    view.Dispose();
            }
            base.Dispose(disposing);
        }

        public View GetView() 
        {
            return Controls.Count > 0 ? Controls[0] as View : null;
        }

        public void SetView(View view) 
        {
            var old_view = GetView();
            if (old_view == view)
                return;
            if (old_view != null) {
                Controls.Clear();
                old_view.Dispose();
            }
            if (view != null) {
                _LockSize = ClientSize = view.Size;
                view.Dock = DockStyle.Fill;
                Controls.Add(view);
            }
            CopyStyle(view);
        }

        public void FinishDialog(DialogResult result)
        {
            this.DialogResult = result;
            this.Close();
        }
    }
}