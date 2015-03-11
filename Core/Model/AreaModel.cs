using EPII.Area;

namespace EPII
{
    [Model(LifeCycle = ModelLifeCycle.Singleton)]
    public class AreaModel
    {
        private AreaHub _AreaHub
            = new AreaHub();

        public AreaHub AreaHub
        {
            get { return _AreaHub; }
        }

        public AreaModel()
        {
        }
    }
}
