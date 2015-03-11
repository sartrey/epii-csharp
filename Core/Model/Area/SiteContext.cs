namespace EPII.Area
{
    public class SiteContext
    {
        private Site _Site = null;
        private AreaContext _Context = null;

        public Site Site 
        {
            get { return _Site; }
        }

        public AreaContext Context
        {
            get { return _Context; }
        }

        public SiteContext(Site site, AreaContext context)
        {
            _Site = site;
            _Context = context;
        }

        public dynamic Process(string request, dynamic data)
        {
            return _Site.Handlers[request].Invoke(_Context, data);
        }

        public dynamic X(string request, dynamic data)
        {
            return Process(request, data);
        }
    }
}
