using System.Linq;

namespace EPII.Area
{
    public class AreaContext : ObjectEx
    {
        private Area _Area = null;
        private Handler[] _Handlers = null;
        private DataContext[] _DataContexts = null;

        private Handler[] Handlers 
        {
            get { return _Handlers; }
        }

        private DataContext[] DataContexts
        {
            get { return _DataContexts; }
        }

        public AreaContext(Area area) 
        {
            _Area = area;
            _Handlers = area.CreateHandlers();
            _DataContexts = area.CreateDataContexts();
        }

        public Handler GetHandler(string name)
        {
            return _Handlers.FirstOrDefault(
                (e) => { return e.Name == name; });
        }

        public DataContext GetDataContext(string name)
        {
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
