namespace EPII.UI.WinForms
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    [ToolboxItem(false)]
    public class BaseControl : Control
    {
        private Table<object> _VEs
            = new Table<object>();

        protected Table<object> VEs
        { 
            get { return _VEs; } 
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
    }
}
