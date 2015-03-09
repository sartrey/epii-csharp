using System;
using System.Collections.Generic;

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
        protected List<Model> _Models
            = new List<Model>();
        protected Table<object> _Data
            = new Table<object>();

        internal List<Model> Models 
        {
            get { return _Models; }
        }

        public Table<object> Data
        {
            get { return _Data; }
        }

        public Runtime()
        {
        }

        public T Use<T>() 
            where T : Model
        {
            lock (_SyncRoot) {
                foreach (var model in _Models) {
                    if (model.GetType() == typeof(T))
                        return model as T;
                }
                var t = (T)Activator.CreateInstance(typeof(T));
                _Models.Add(t);
                return t;
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