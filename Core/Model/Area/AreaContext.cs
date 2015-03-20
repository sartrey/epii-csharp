using System.Linq;

namespace EPII.Area
{
    public class AreaContext : ObjectEx
    {
        public static AreaContext GetCurrentContext(Area area)
        {
            var contexts = ContextTable.CurrentContextTable;
            var context = contexts[area.Name];
            if (context == null)
                contexts[area.Name] = new AreaContext(area);
            return context;
        }

        private Area _Area = null;
        private DataAccess[] _DataAccesses = null;

        public Area Area
        {
            get { return _Area; }
        }

        private AreaContext(Area area)
        {
            _Area = area;
        }

        public DataAccess GetDataAccess(string name)
        {
            if (_DataAccesses == null)
                _DataAccesses = _Area.CreateDataAccesses();
            return _DataAccesses.FirstOrDefault(
                (e) => { return e.Name == name; });
        }

        public void Commit()
        {
            foreach (var access in _DataAccesses)
                access.Commit();
        }

        protected override void DisposeManaged()
        {
            foreach (var access in _DataAccesses) {
                access.Close();
                access.Dispose();
            }
        }

        protected override void DisposeNative()
        {
        }
    }
}