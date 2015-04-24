using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void UpdateViewModel(bool render = true)
        {
            throw new NotImplementedException();
        }
    }
}
