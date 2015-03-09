using EPII.Area;

namespace EPII
{
    public class AreaModel : Model
    {
        private AreaHub _AreaHub = null;

        public AreaHub AreaHub 
        {
            get { return _AreaHub; }
        }

        public AreaModel() 
        {
            _AreaHub = new AreaHub();
        }
    }
}
