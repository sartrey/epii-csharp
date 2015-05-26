namespace EPII.Area
{
    public class Startup : ISingletonModel
    {
        private AreaHub area_hub_ = null;
        
        public AreaHub AreaHub
        {
            get { return area_hub_; }
        }

        public Startup()
        {
            area_hub_ = new AreaHub();
        }
    }
}