using EPII.Area;

namespace EPII
{
    [Model(LifeCycle = ModelLifeCycle.Singleton)]
    public class AreaModel
    {
        private AreaHub _AreaHub = null;
        private ContextTable _Contexts = null;

        public AreaHub AreaHub
        {
            get { return _AreaHub; }
        }

        public AreaModel()
        {
            _AreaHub = new AreaHub();
            _Contexts = new ContextTable();
        }
    }
}