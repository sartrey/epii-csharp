using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.UI
{
    public class WindowPool
    {
        private List<IWindow> _Caches;
        private object _SyncRoot;

        public IWindow GetWindow() 
        {
            return null;
        }
    }
}
