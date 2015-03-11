using System.Linq;

namespace EPII.Area
{
    public class AreaContext : ObjectEx
    {
        private Area _Area = null;
        private DataContext[] _DataContexts = null;

        public Area Area 
        {
            get { return _Area; }
        }

        public AreaContext(Area area) 
        {
            _Area = area;
        }

        public SiteContext GetSiteContext(string name)
        {
            var site = _Area.GetSite(name);
            if (site == null)
                return null;
            return new SiteContext(site, this);
        }

        public DataContext GetDataContext(string name)
        {
            if (_DataContexts == null)
                _DataContexts = _Area.CreateDataContexts();
            return _DataContexts.FirstOrDefault(
                (e) => { return e.Name == name; });
        }

        public void Commit()
        {
            foreach (var context in _DataContexts)
                context.Commit();
        }

        protected override void DisposeManaged()
        {
            foreach (var context in _DataContexts) {
                context.Close();
                context.Dispose();
            }
        }

        protected override void DisposeNative()
        {
        }
    }
}
