namespace EPII.Front
{
    using System.Collections.Generic;

    public partial class Startup : ISingletonModel
    {
        private Director director_ = null;
        private ViewPool view_pool_ = null;
        private WindowPool window_pool_ = null;

        public Director Director 
        {
            get { return director_; }
        }

        public ViewPool ViewPool 
        {
            get { return view_pool_; }
        }

        public WindowPool WindowPool 
        {
            get { return window_pool_; }
        }

        public Startup()
        {
            director_ = new Director();
            view_pool_ = new ViewPool();
            window_pool_ = new WindowPool();
        }
    }
}
