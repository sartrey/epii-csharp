using EPII.Area;

namespace EPII
{
    [Model(IsSingleton = true)]
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
