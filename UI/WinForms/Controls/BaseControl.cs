namespace EPII.UI.WinForms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    [ToolboxItem(false)]
    public class BaseControl : Control
    {
        private Table<object> _VEs
            = new Table<object>();
        private MouseState _MouseState 
            = new MouseState();

        protected Table<object> VEs
        { 
            get { return _VEs; } 
        }

        protected MouseState MouseState 
        {
            get { return _MouseState; }
        }

        public BaseControl() 
        {
            BuildVEs(_VEs);
        }

        /// <summary>
        /// build visual elements
        /// </summary>
        protected virtual void BuildVEs(Table<object> ves) { }

        protected void ClearVEs()
        {
            foreach (var key in _VEs.Keys) {
                var ve = _VEs[key] as IDisposable;
                if (ve != null)
                    ve.Dispose();
            }
            _VEs.Clear();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _MouseState.Buttons = e.Button;
            _MouseState.Location = new Point(e.X, e.Y);
        }
    }
}
