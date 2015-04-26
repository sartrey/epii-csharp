using EPII.FEA;
using System;
using System.Windows.Forms;

namespace EPII.UI.WinForms
{
    public class ViewEx : ObjectEx, IView
    {
        private Control _ViewCore = null;

        internal Control ViewCore 
        {
            get { return _ViewCore; }
        }

        public void Bind(IViewModel viewmodel)
        {
            throw new NotImplementedException();
        }

        protected override void DisposeManaged()
        {
            _ViewCore.Dispose();
        }

        protected override void DisposeNative()
        {
        }
    }
}
