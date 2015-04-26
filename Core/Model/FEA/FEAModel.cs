namespace EPII.FEA
{
    [Model(LifeCycle = LifeCycles.Singleton)]
    public class FEAModel : IModel
    {
        private ViewHub _ViewHub = null;
        private WindowPool _WindowPool = null;
        
        public ViewHub ViewHub
        {
            get { return _ViewHub; }
        }

        public WindowPool WindowPool 
        {
            get { return _WindowPool; }
        }

        public IModelSettings Settings
        {
            get { throw new System.NotImplementedException(); }
        }

        public FEAModel()
        {
            _ViewHub = new ViewHub();
            _WindowPool = new WindowPool();
        }

        public bool Identify()
        {
            return false;
        }
    }
}
