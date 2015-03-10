using System;
using System.Collections.Generic;

namespace EPII.Area
{
    public abstract class Handler
    {
        protected AreaContext _Context
            = null;

        public AreaContext Context
        {
            get { return _Context; }
            internal set { _Context = value; }
        }

        public abstract string Name { get; }

        public Handler(AreaContext context)
        {
            _Context = context;
        }

        public abstract dynamic Process(string request, dynamic data);

        public dynamic X(string request, dynamic data) 
        {
            return Process(request, data);
        }
    }
}
