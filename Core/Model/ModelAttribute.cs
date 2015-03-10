using System;

namespace EPII
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ModelAttribute : Attribute
    {
        private bool _IsSingleton = false;

        public bool IsSingleton 
        {
            get { return _IsSingleton; }
            set { _IsSingleton = value; }
        }
    }
}
