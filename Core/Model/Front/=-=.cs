namespace EPII.Front
{
    using System.Collections.Generic;

    public partial class Startup : ISingletonModel
    {
        private Director _Director = null;
        private ViewPool _ViewPool = null;
        private WindowPool _WindowPool = null;

        public Director Director 
        {
            get { return _Director; }
        }

        public ViewPool ViewPool 
        {
            get { return _ViewPool; }
        }

        public WindowPool WindowPool 
        {
            get { return _WindowPool; }
        }

        public Startup()
        {
            _Director = new Director();
        }
    }
}
