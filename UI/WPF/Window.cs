using EPII.FEA;
using System.Windows;
using System.Windows.Controls;

namespace EPII.UI.WPF
{
    public class Window : IWindow
    {
        private System.Windows.Window _WindowCore = null;

        public bool HasView
        {
            get { return _WindowCore.Content != null; }
        }

        public IView View
        {
            get { return _WindowCore.Content as IView; }
            set
            {
                if (HasView)
                    return;
                var view = value as UserControl;
                if (view == null)
                    return;
                _WindowCore.Content = view;
                AdaptView();
            }
        }

        public Window()
        {
            _WindowCore = new System.Windows.Window();
        }

        private void AdaptView()
        {
            _WindowCore.SizeToContent = SizeToContent.WidthAndHeight;
            _WindowCore.ResizeMode = ResizeMode.NoResize;
            _WindowCore.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            var content = View as UserControl;
            content.Width = content.MaxWidth;
            content.Height = content.MaxHeight;
        }

        public void Open()
        {
            _WindowCore.Show();
        }

        public void Close()
        {
            _WindowCore.Hide();
            _WindowCore.Content = null;
        }
    }
}
