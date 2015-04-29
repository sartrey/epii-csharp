namespace EPII.Front
{
    using System.Collections.Generic;

    public partial class Startup : ISingletonModel
    {
        private WindowPool _WindowPool = null;
        private Director _Director = null;
        
        public WindowPool WindowPool 
        {
            get { return _WindowPool; }
        }

        public Director Director 
        {
            get { return _Director; }
        }

        public Startup()
        {
            _WindowPool = new WindowPool();
            _Director = new Director();
        }
    }
}
