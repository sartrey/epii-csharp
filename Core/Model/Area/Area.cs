using System;

namespace EPII.Area
{
    public abstract class Area
    {
        protected Table<object> _Shares 
            = new Table<object>();

        public abstract Guid Id { get; }

        public abstract string Name { get; }

        public Table<object> Shares 
        {
            get { return _Shares; }
        }

        public Area() 
        {
            CreateShares();
        }

        protected virtual void CreateShares() 
        {
        }

        internal abstract Handler[] CreateHandlers();

        internal abstract DataContext[] CreateDataContexts();
    }
}