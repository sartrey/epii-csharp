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

        private Area area_ = null;
        private DataAccess[] data_accesses_ = null;

        public Area Area
        {
            get { return area_; }
        }

        private AreaContext(Area area)
        {
            area_ = area;
        }

        public DataAccess GetDataAccess(string name)
        {
            if (data_accesses_ == null)
                data_accesses_ = area_.CreateDataAccesses();
            return data_accesses_.FirstOrDefault(
                (e) => { return e.Name == name; });
        }

        public void Commit()
        {
            foreach (var access in data_accesses_)
                access.Commit();
        }

        protected override void DisposeManaged()
        {
            foreach (var access in data_accesses_) {
                access.Close();
                access.Dispose();
            }
        }

        protected override void DisposeNative()
        {
        }
    }
}