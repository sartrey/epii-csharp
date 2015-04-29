namespace EPII.Area
{
    public class Startup : ISingletonModel
    {
        private AreaHub _AreaHub = null;
        
        public AreaHub AreaHub
        {
            get { return _AreaHub; }
        }

        public Startup()
        {
            _AreaHub = new AreaHub();
        }
    }
}