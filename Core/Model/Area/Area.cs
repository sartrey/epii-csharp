using System;

namespace EPII.Area
{
    public abstract class Area
    {
        protected Table<object> _Shares 
            = new Table<object>();

        public abstract Guid Id { get; }

        public abstract string Name { get; }

        protected Table<object> Shares 
        {
            get { return _Shares; }
        }

        public Area() 
        {
        }

        public abstract AreaContext CreateContext();
    }
}