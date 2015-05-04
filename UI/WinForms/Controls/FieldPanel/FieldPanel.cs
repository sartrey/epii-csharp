namespace EPII.UI.WinForms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [ToolboxItem(true)]
    [Designer(typeof(EPII.UI.WinForms.FieldPanelDesigner))]
    public class FieldPanel : BaseControl
    {
        private string _HeaderText = null;
        private string _NoteText = null;
        private bool _SpanLocked = false;

        private Size _HeaderSize = new Size(0, 0);
        private Size _NoteSize = new Size(0, 0);

        private Brush TextBrush
        {
            get
            {
                var brush = VEs["text_brush"];
                if (brush == null ||
                    (brush as SolidBrush).Color != ForeColor) {
                    brush = new SolidBrush(ForeColor);
                    VEs["text_brush"] = brush;
                }
                return (Brush)brush;
            }
        }

        public override string Text
        {
            get { return HeaderText; }
            set { HeaderText = value; }
        }

        [Category("Field")]
        public Control Content
        {
            get
            {
                if (Controls.Count > 0)
                    return Controls[0];
                return null;
            }
            set
            {
                if (Controls.Count > 0) {
                    var old_control = Controls[0];
                    if (value == old_control)
                        return;
                    old_control.Dispose();
                    Controls.Clear();
                } 
                var new_control = value as Control;
                if (new_control != null) {
                    Controls.Add(new_control);
                }
                OnSizeChanged(null);
            }
        }

        [Category("Field")]
        public string HeaderText
        {
            get { return _HeaderText; }
            set
            {
                _HeaderText = value;
                UpdateTextSpan();
                Refresh();
            }
        }

        [Category("Field")]
        public string NoteText
        {
            get { return _NoteText; }
            set
            {
                _NoteText = value;
                UpdateTextSpan();
                Refresh();
            }
        }

        [Category("Field")]
        public bool SpanLocked
        {
            get { return _SpanLocked; }
            set
            {
                _SpanLocked = value;
                UpdateTextSpan();
            }
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

        public FieldPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Size = new Size(240, 30);
            HeaderText = "Header";
            NoteText = "Note";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            if (DesignMode) {
                var rect = new Rectangle(0, 0, Width, Height);
                var pen1 = new Pen(new SolidBrush(Color.DarkGray), 2);
                pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                var pen2 = new Pen(new SolidBrush(Color.Orange), 1.5f);
                pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawRectangle(pen1, rect);
                graphics.DrawRectangle(pen2,
                    new Rectangle(Padding.Left + _HeaderSize.Width + 3, 0,
                        Width - Padding.Left - Padding.Right - _HeaderSize.Width - _NoteSize.Width - 6,
                        Height));
            }
            graphics.DrawString(_HeaderText, Font, TextBrush,
                Padding.Left, (Height - _HeaderSize.Height) / 2);
            graphics.DrawString(_NoteText, Font, TextBrush,
                Width - Padding.Right - _NoteSize.Width,
                (Height - _NoteSize.Height) / 2);
            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            var control = Content as Control;
            if (control != null) {
                control.Left = Padding.Left + _HeaderSize.Width + 3;
                control.Top = Padding.Top;
                var width = Width - 6
                        - Padding.Left - Padding.Right
                        - HeaderSpan - NoteSpan;
                if (width < 0) width = 0;
                control.Width = width;
                control.Height = Height - Padding.Top - Padding.Bottom;
            }
            base.OnSizeChanged(e);
            Refresh();
        }

        protected void UpdateTextSpan()
        {
            if (!SpanLocked) {
                var graphics = CreateGraphics();
                _HeaderSize = graphics.MeasureString(_HeaderText, Font).ToSize();
                _NoteSize = graphics.MeasureString(_NoteText, Font).ToSize();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                var control = Content as Control;
                if (control != null) {
                    control.Dispose();
                    Controls.Clear();
                }
                ClearVEs();
            }
            base.Dispose(disposing);
        }
    }
}
