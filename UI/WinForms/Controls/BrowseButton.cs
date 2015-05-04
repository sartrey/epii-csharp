using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    [ToolboxItem(true)]
    public class BrowseButton : BaseControl
    {
        public enum BrowseMode
        {
            OpenFile,
            SaveFile,
            Directory
        }

        private BrowseMode _Mode
            = BrowseMode.OpenFile;
        private CommonDialog _Dialog = null;
        private string _Tip = null;
        private string _Path = null;

        private bool _IsMouseMove = false;

        private Brush TextBrush
        {
            get
            {
                var brush = VEs["text_brush"] as SolidBrush;
                if (brush == null || brush.Color != ForeColor) {
                    brush = new SolidBrush(ForeColor);
                    VEs["text_brush"] = brush;
                }
                return brush;
            }
        }

        private Brush MouseMoveBrush 
        {
            get { return VEs["move_brush"] as SolidBrush; }
        }

        private Brush MouseLeaveBrush
        {
            get { return VEs["leave_brush"] as SolidBrush; }
        }

        [Category("Browse")]
        public BrowseMode Mode
        {
            get { return _Mode; }
            set 
            {
                _Mode = value;
                UpdateDialog();
            }
        }

        [Category("Browse")]
        public string Tip 
        {
            get { return _Tip; }
            set 
            {
                _Tip = value; 
                Refresh();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CommonDialog Dialog
        {
            get
            {
                if (_Dialog == null)
                    UpdateDialog();
                return _Dialog;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Path
        {
            get { return _Path; }
            set 
            {
                _Path = value;
                Refresh();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPathExist
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_Path))
                    return false;
                return (_Mode == BrowseMode.Directory ?
                    Directory.Exists(_Path) : File.Exists(_Path));
            }
        }

        public BrowseButton()
        {
            Size = new Size(240, 30);
        }

        protected override void BuildVEs(Table<object> ves)
        {
            base.BuildVEs(ves);
            ves["move_brush"] = new SolidBrush(Color.Orange);
            ves["leave_brush"] = new SolidBrush(Color.LightBlue);
            ves["text_brush"] = new SolidBrush(ForeColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var tip_size = graphics.MeasureString(_Tip, Font);
            graphics.DrawString(_Tip, Font, TextBrush,
                (Width - tip_size.Width) / 2, (Height - tip_size.Height) / 2);
            graphics.DrawRectangle(new Pen(Color.DarkGray, 2), new Rectangle(0, 0, Width, Height));
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.Clear(BackColor);
            if (_IsMouseMove)
                graphics.FillRectangle(MouseMoveBrush, new Rectangle(0, 0, Width, Height));
            else
                graphics.FillRectangle(MouseLeaveBrush, new Rectangle(0, 0, Width, Height));
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _IsMouseMove = true;
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _IsMouseMove = false;
            Refresh();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            var result = Dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            UpdateData();
        }

        protected void UpdateDialog()
        {
            if (_Dialog != null)
                _Dialog.Dispose();
            if (_Mode == BrowseMode.OpenFile)
                _Dialog = new OpenFileDialog();
            else if (_Mode == BrowseMode.SaveFile)
                _Dialog = new SaveFileDialog();
            else if (_Mode == BrowseMode.Directory)
                _Dialog = new FolderBrowserDialog();
        }

        protected void UpdateData() 
        {
            if (_Mode == BrowseMode.OpenFile)
                Path = (_Dialog as OpenFileDialog).FileName;
            else if (_Mode == BrowseMode.SaveFile)
                Path = (_Dialog as SaveFileDialog).FileName;
            else if (_Mode == BrowseMode.Directory)
                Path = (_Dialog as FolderBrowserDialog).SelectedPath;
        }
    }
}
