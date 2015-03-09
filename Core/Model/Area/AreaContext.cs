using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.Area
{
    public abstract class AreaContext : ObjectEx
    {
        protected Handler[] _Handlers = null;
        protected DataContext[] _DataContexts = null;

        internal Handler[] Handlers 
        {
            get { return _Handlers; }
        }

        internal DataContext[] DataContexts
        {
            get { return _DataContexts; }
        }

        protected override void DisposeManaged()
        {
            foreach (var context in _DataContexts)
                context.Dispose();
        }

        protected override void DisposeNative()
        {
        }
    }
}
