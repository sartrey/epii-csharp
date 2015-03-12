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

        public bool IsSpanLocked 
        {
            get { return _IsSpanLocked; }
            set { _IsSpanLocked = value; }
        }

        public int HeaderSpan
        {
            get { return _HeaderSize.Width; }
            set { _HeaderSize.Width = value; }
        }

        public int NoteSpan 
        {
            get { return _NoteSize.Width; }
            set { _NoteSize.Width = value; }
        }

        [Browsable(false)]
        public Control Input
        {
            get { return Controls.Count > 0 ? Controls[0] : null; }
            set 
            {
                var input = Input;
                if (value == input)
                    return;
                if (input != null)
                    input.Dispose();
                input = value;
                Controls.Clear();
                Controls.Add(input);
                OnSizeChanged(null);
            }
        }

        public FieldControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Width = 300;
            Height = 30;
            Header = "Header";
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
            var input = Input;
            if (input != null) {
                input.Top = Padding.Top;
                input.Left = Padding.Left + _HeaderSize.Width + 3;
                var width = Width - 6
                    - Padding.Left - Padding.Right
                    - HeaderSpan - NoteSpan;
                if (width < 0)
                    width = 0;
                input.Width = width;
                input.Height = Height - Padding.Top - Padding.Bottom;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing) 
            {
                var input = Input;
                if (input != null)
                    input.Dispose();
                Controls.Clear();
            }
            base.Dispose(disposing);
        }
    }
}
