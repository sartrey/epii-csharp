using System;
using System.Collections.Generic;
using System.Reflection;

namespace EPII
{
    public class Runtime : ObjectEx
    {
        private static object _CtorMutex = null;
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

        public static void Register<T>(bool locked = false)
            where T : Runtime, new()
        {
            if(_CtorMutex == null)
                _Instance = new T();
            if (locked)
                _CtorMutex = new object();
        }

        private object _SyncRoot = new object();
        private List<IModel> _Models
            = new List<IModel>();
        private Table<object> _Data
            = new Table<object>();

        public Table<object> Data
        {
            get { return _Data; }
        }

        public Runtime()
        {
        }

        public T Use<T>()
            where T : IModel
        {
            var type = typeof(T) as MemberInfo;
            var attrib = Attribute.GetCustomAttribute(
                type, typeof(ModelAttribute)) as ModelAttribute;
            if (attrib == null)
                throw new Exception("model attribute not found");
            if (attrib.LifeCycle == LifeCycles.Transient) {
                var t = (T)Activator.CreateInstance(typeof(T));
                return t;
            } else {
                lock (_SyncRoot) {
                    var t = attrib.LifeCycle == LifeCycles.Instance ? 
                        _Models.Find(e => e.Identify()) : 
                        _Models.Find(e => e.GetType() == typeof(T));
                    if(t == null)
                        t = (IModel)Activator.CreateInstance(typeof(T));
                    _Models.Add(t);
                    return (T)t;
                }
            }
        }

        public T Use<T>(Action<IModelSettings> setup)
            where T : IModel
        {
            var instance = Use<T>();
            if (instance != null) {
                setup(instance.Settings);
            }
            return instance;
        }

        protected override void DisposeManaged()
        {
            foreach (var key in _Data.Keys) {
                var item = _Data[key] as IDisposable;
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