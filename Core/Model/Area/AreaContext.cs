using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.Area
{
    public abstract class AreaContext : ObjectEx
    {
        protected Area _Area = null;
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

        public AreaContext(Area area) 
        {
            _Area = area;
            CreateHandlers();
            CreateDataContexts();
        }

        protected abstract void CreateHandlers();

        protected abstract void CreateDataContexts();

        public Handler GetHandler(string name)
        {
            foreach (var handler in _Handlers)
                if (handler.Name == name)
                    return handler;
            return null;
        }

        public DataContext GetDataContext(string name)
        {
            foreach (var context in _DataContexts)
                if (context.Name == name)
                    return context;
            return null;
        }

        protected override void DisposeManaged()
        {
            foreach (var context in _DataContexts) {
                context.Close();
                context.Dispose();
            }
            _Area = null;
        }

        protected override void DisposeNative()
        {
        }
    }
}
