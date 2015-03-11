using System;

namespace EPII
{
    public enum ModelLifeCycle
    {
        Transient,
        Singleton
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ModelAttribute : Attribute
    {
        private ModelLifeCycle _LifeCycle = ModelLifeCycle.Transient;

        public ModelLifeCycle LifeCycle
        {
            get { return _LifeCycle; }
            set { _LifeCycle = value; }
        }
    }
}