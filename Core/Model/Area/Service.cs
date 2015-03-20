using System;

namespace EPII.Area
{
    public delegate dynamic XHandler(dynamic data);

    public abstract class Service
    {
        private static Table<XHandler> _XHandlers
            = new Table<XHandler>();

        private Area _Area = null;

        internal Service(Area area)
        {
            _Area = area;
        }

        public dynamic X(string request, dynamic data)
        {
            var handler = _XHandlers[request];
            if (handler != null)
                return handler(data);
            var method = GetType().GetMethod(request);
            if (method != null) {
                try {
                    handler = (XHandler)Delegate.CreateDelegate(
                        typeof(XHandler), method);
                    _XHandlers.Add(request, handler);
                    return handler(data);
                } catch {
                    throw new NotImplementedException();
                }
            }
            throw new NotImplementedException();
        }
    }
}