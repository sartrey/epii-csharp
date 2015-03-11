using System;

namespace EPII.Area
{
    public abstract class Site
    {
        internal delegate dynamic SiteHandler(
            AreaContext context, dynamic data);
        internal Table<SiteHandler> _Handlers 
            = new Table<SiteHandler>();

        internal Table<SiteHandler> Handlers 
        {
            get { return _Handlers; }
        }

        public abstract string Name { get; }

        internal void CacheHandlers() 
        {
            var methods = GetType().GetMethods();
            foreach (var method in methods) {
                var attrib = Attribute.GetCustomAttribute(
                    method, typeof(HandlerAttribute));
                if (attrib != null) {
                    var d = (SiteHandler)Delegate.CreateDelegate(
                        typeof(SiteHandler), method);
                    _Handlers.Add(method.Name, d);
                }
            }
        }
    }
}
