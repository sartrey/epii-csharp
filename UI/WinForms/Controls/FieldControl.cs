using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class FieldControl : Control
    {
        private string _HeaderText = null;
        private string _NoteText = null;
        private bool _IsSpanLocked = false;
        private Size _HeaderSize = new Size(0, 0);
        private Size _NoteSize = new Size(0, 0);
        private Brush _TextBrush = null;

        private Brush TextBrush
        {
            get 
            {
                if (_TextBrush == null || 
                    (_TextBrush as SolidBrush).Color != ForeColor)
                    _TextBrush = new SolidBrush(ForeColor);
                return _TextBrush;
            }
        }

        public override string Text
        {
            get { return Header; }
            set { Header = value; }
        }

        [Category("Field")]
        public string Header 
        {
            get { return _HeaderText; }
            set
            {
                _HeaderText = value;
                if(!_IsSpanLocked)
                    UpdateSpan();
            }
        }

        [Category("Field")]
        public string Note 
        {
            get { return _NoteText; }
            set 
            {
                _NoteText = value;
                if (!_IsSpanLocked)
                    UpdateSpan();
            }
        }

        [Category("Field")]
        public bool IsSpanLocked 
        {
            get { return _IsSpanLocked; }
            set { _IsSpanLocked = value; }
        }

        [Category("Field")]
        public int HeaderSpan
        {
            get { return _HeaderSize.Width; }
            set { _HeaderSize.Width = value; }
        }

        [Category("Field")]
        public int NoteSpan 
        {
            get { return _NoteSize.Width; }
            set { _NoteSize.Width = value; }
        }

        public FieldControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Width = 300;
            Height = 24;
            Note = "Note";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;
            graphics.DrawString(_HeaderText, Font, TextBrush, 
                Padding.Left, (Height - _HeaderSize.Height) / 2);
            graphics.DrawString(_NoteText, Font, TextBrush,
                Right - Padding.Right - _NoteSize.Width, 
                (Height - _NoteSize.Height) / 2);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            var content = GetContent();
            if (content != null) {
                content.Top = Padding.Top;
                content.Left = Padding.Left + _HeaderSize.Width + 3;
                var width = Width - 6
                    - Padding.Left - Padding.Right
                    - HeaderSpan - NoteSpan;
                if (width < 0)
                    width = 0;
                content.Width = width;
                content.Height = Height - Padding.Top - Padding.Bottom;
            }
            base.OnSizeChanged(e);
            Refresh();
        }

        protected void UpdateSpan()
        {
            var graphics = CreateGraphics();
            if (!_IsSpanLocked) {
                _HeaderSize = graphics.MeasureString(_HeaderText, Font).ToSize();
                _NoteSize = graphics.MeasureString(_NoteText, Font).ToSize();
            }
        }

        public Control GetContent() 
        {
            return Controls.Count > 0 ? Controls[0] : null;
        }

        public void SetContent(Control control) 
        {
            var old_content = GetContent();
            if (control == old_content)
                return;
            if (old_content != null)
                old_content.Dispose();
            Controls.Clear();
            Controls.Add(control);
            OnSizeChanged(null);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) 
            {
                var content = GetContent();
                if (content != null)
                    content.Dispose();
                Controls.Clear();
                _TextBrush.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
