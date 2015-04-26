namespace EPII.Area
{
    [Model(LifeCycle = LifeCycles.Singleton)]
    public class AreaModel : IModel
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

        public bool Identify()
        {
            return false;
        }
    }
}