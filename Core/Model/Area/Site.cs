using System;
using System.Reflection;

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
            var valid = new Func<MethodInfo, bool>(
                (e) => {
                    if (e.ReturnType != typeof(object))
                        return false;
                    var ps = e.GetParameters();
                    if (ps.Length != 2 ||
                        ps[0].ParameterType != typeof(AreaContext) ||
                        ps[1].ParameterType != typeof(object))
                        return false;
                    return true;
                });
            var methods = GetType().GetMethods();
            foreach (var method in methods) {
                if (valid(method)) {
                    var d = (SiteHandler)Delegate.CreateDelegate(
                        typeof(SiteHandler), method);
                    _Handlers.Add(method.Name, d);
                }
            }
        }
    }
}
