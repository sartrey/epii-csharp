using System.Linq;

namespace EPII.Area
{
    public class AreaContext : ObjectEx
    {
        private Area _Area = null;
        private Site[] _Sites = null;
        private DataContext[] _DataContexts = null;

        public Area Area 
        {
            get { return _Area; }
        }

        public AreaContext(Area area) 
        {
            _Area = area;
        }

        public Site GetSite(string name)
        {
            if (_Sites == null)
                _Sites = _Area.CreateSites();
            return _Sites.FirstOrDefault(
                (e) => { return e.Name == name; });
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
