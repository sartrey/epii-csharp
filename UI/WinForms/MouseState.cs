using System.Drawing;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class MouseState
    {
        private MouseButtons _Buttons 
            = MouseButtons.None;
        private Point _Location;

        public MouseButtons Buttons 
        {
            get { return _Buttons; }
            set { _Buttons = value; }
        }

        public Point Location 
        {
            get { return _Location; }
            set { _Location = value; }
        }

        public MouseState() 
        {
        }
    }
}
