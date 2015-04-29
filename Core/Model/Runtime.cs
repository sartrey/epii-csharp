namespace EPII
{
    using System;
    using System.Collections.Generic;

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
        private List<ISingletonModel> _SingletonModels
            = new List<ISingletonModel>();
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
            where T : IModel, new()
        {
            var type = typeof(T);
            var is_transient = type.GetInterface("ITransientModel") != null;
            //var is_singleton = type.GetInterface("ISingletonModel") != null;
            if (is_transient) {
                var t = (T)Activator.CreateInstance(typeof(T));
                return t;
            } else {
                lock (_SyncRoot) {
                    var t = _SingletonModels.Find(e => e.GetType() == typeof(T));
                    if(t == null)
                        t = (ISingletonModel)(new T());
                    _SingletonModels.Add(t);
                    return (T)t;
                }
            }
        }

        public T Use<T>(Func<T, bool> setup)
            where T : IModel, new()
        {
            var instance = Use<T>();
            if (instance != null) {
                if (!setup(instance)) {
                    Diagnose.TraceError(
                        "Runtime", "Use", "setup error");
                }
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
            foreach (var model in _SingletonModels) {
                var item = model as IDisposable;
                if (item != null)
                    item.Dispose();
            }
            _SingletonModels.Clear();
        }

        protected override void DisposeNative()
        {
        }
    }
}