using System;

namespace EPII.Area
{
    internal delegate dynamic XHandler(dynamic data);

    public abstract class Site
    {
        protected AreaContext _Context = null;

        public AreaContext Context
        {
            get { return _Context; }
        }

        public abstract string Name { get; }

        public Site(AreaContext context) 
        {
            _Context = context;
        }

        public dynamic X(string request, dynamic data)
        {
            var handler = _Context.Area.XHandlers[request];
            if (handler != null)
                return handler(data);
            var methods = GetType().GetMethods();
            foreach (var method in methods) {
                if (method.Name == request) {
                    try {
                        handler = (XHandler)Delegate.CreateDelegate(
                            typeof(XHandler), method);
                        _Context.Area.XHandlers.Add(request, handler);
                        return handler(data);
                    } catch {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
