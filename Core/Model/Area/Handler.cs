using System;

namespace EPII.Area
{
    public abstract class Handler
    {
        protected Area _Area
            = null;

        public Area Area
        {
            get { return _Area; }
        }

        public abstract string Name { get; }

        public Handler(Area area)
        {
            _Area = area;
        }

        public void Perform() 
        {
        }

        public void X() 
        {
        }
    }
}
