using System;

namespace EPII.Area
{
    public abstract class Area
    {
        internal Table<XHandler> _XHandlers
            = new Table<XHandler>();
        protected Table<object> _Shares 
            = new Table<object>();

        public abstract Guid Id { get; }

        public abstract string Name { get; }

        public Table<object> Shares 
        {
            get { return _Shares; }
        }

        internal Table<XHandler> XHandlers 
        {
            get { return _XHandlers; }
        }

        public Area() 
        {
        }

        internal abstract Site[] CreateSites();

        internal abstract DataContext[] CreateDataContexts();
    }
}