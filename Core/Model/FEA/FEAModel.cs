namespace EPII.FEA
{
    [Model(LifeCycle = LifeCycles.Singleton)]
    public class FEAModel : IModel
    {
        private WindowPool _WindowPool = null;
        
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
            _WindowPool = new WindowPool();
        }

        public bool Identify()
        {
            return false;
        }
    }
}
