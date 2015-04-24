using System;

namespace EPII
{
    public enum LifeCycles
    {
        Instance,
        Transient,
        Singleton
    }

    [AttributeUsage(
        AttributeTargets.Class, 
        AllowMultiple = false, Inherited = true)]
    public class ModelAttribute : Attribute
    {
        private LifeCycles _LifeCycle 
            = LifeCycles.Transient;

        public LifeCycles LifeCycle
        {
            get { return _LifeCycle; }
            set { _LifeCycle = value; }
        }
    }
}