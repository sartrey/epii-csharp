using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class BrowseField : FieldControl
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

        public BrowseMode Mode
        {
            get { return _Mode; }
            set 
            {
                _Mode = value;
                UpdateDialog();
            }
        }

        public string Tip 
        {
            get { return _Tip; }
            set 
            {
                _Tip = value;
                var label = GetContent() as Label;
                if (string.IsNullOrEmpty(label.Text))
                    label.Text = _Tip;
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
                var label = GetContent() as Label;
                label.Text = (!string.IsNullOrEmpty(value) ? 
                    value : _Tip);
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

        public BrowseField()
        {
            var label = new Label();
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.MouseMove += Browse_MouseMove;
            label.MouseLeave += Browse_MouseLeave;
            label.Click += Browse_Click;
            SetContent(label);
            SetBrowseStyle(false);
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

        private void SetBrowseStyle(bool hover)
        {
            var label = GetContent() as Label;
            if (hover)
            {
                label.BackColor = Color.Orange;
                label.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                label.BackColor = Color.LightCyan;
                label.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void Browse_MouseMove(object sender, MouseEventArgs e)
        {
            SetBrowseStyle(true);
        }

        private void Browse_MouseLeave(object sender, EventArgs e)
        {
            SetBrowseStyle(false);
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            var result = Dialog.ShowDialog();
            if (result != DialogResult.OK)
                return;
            UpdateData();
        }
    }
}
