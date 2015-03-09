using System;
using System.Collections.Generic;

namespace EPII.Area
{
    public abstract class Area
    {
        public abstract Guid Id { get; }

        public abstract string Name { get; }

        public abstract AreaContext CreateContext();
    }
}