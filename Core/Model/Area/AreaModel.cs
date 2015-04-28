namespace EPII.Area
{
    public class AreaModel : ISingletonModel
    {
        private AreaHub _AreaHub = null;
        
        public AreaHub AreaHub
        {
            get { return _AreaHub; }
        }

        public IModelSettings Settings
        {
            get { throw new System.NotImplementedException(); }
        }

        public AreaModel()
        {
            _AreaHub = new AreaHub();
        }
    }
}