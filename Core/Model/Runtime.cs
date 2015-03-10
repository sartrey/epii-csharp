using System;
using System.Collections.Generic;
using System.Reflection;

namespace EPII
{
    public class Runtime : ObjectEx
    {
        private static Runtime _Instance = null;

        /// <summary>
        /// get runtime single instance
        /// </summary>
        public static Runtime Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Runtime();
                return _Instance;
            }
        }

        protected object _SyncRoot = new object();
        protected List<object> _SingletonModels
            = new List<object>();
        protected Table<object> _Data
            = new Table<object>();

        internal List<object> SingletonModels 
        {
            get { return _SingletonModels; }
        }

        public Table<object> Data
        {
            get { return _Data; }
        }

        public Runtime()
        {
        }

        public T Use<T>()
            where T : class
        {
            var type = typeof(T) as MemberInfo;
            var attrib = Attribute.GetCustomAttribute(
                type, typeof(ModelAttribute)) as ModelAttribute;
            if (attrib == null)
                return null;
            if (attrib.IsSingleton) {
                var t = (T)Activator.CreateInstance(typeof(T));
                return t;
            } else {
                lock (_SyncRoot) {
                    foreach (var model in _SingletonModels) {
                        if (model.GetType() == typeof(T))
                            return model as T;
                    }
                    var t = (T)Activator.CreateInstance(typeof(T));
                    _SingletonModels.Add(t);
                    return t;
                }
            }
        }

        protected override void DisposeManaged()
        {
            foreach (var key in _Data.Keys) {
                var item = _Data[key] as ObjectEx;
                if (item != null)
                    item.Dispose();
            }
            _Data.Clear();
        }

        protected override void DisposeNative()
        {
        }
    }
}