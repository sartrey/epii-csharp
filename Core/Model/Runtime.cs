namespace EPII
{
    using System;
    using System.Collections.Generic;

    public class Runtime : ObjectEx
    {
        private static object ctor_mutex = null;
        private static Runtime instance_ = null;

        /// <summary>
        /// get runtime single instance
        /// </summary>
        public static Runtime Instance
        {
            get
            {
                if (instance_ == null)
                    instance_ = new Runtime();
                return instance_;
            }
        }

        public static void Register<T>(bool locked = false)
            where T : Runtime, new()
        {
            if(ctor_mutex == null)
                instance_ = new T();
            if (locked)
                ctor_mutex = new object();
        }

        private object model_mutex_ = new object();
        private List<ISingletonModel> singleton_models_
            = new List<ISingletonModel>();

        public Runtime()
        {
        }

        public T Use<T>()
            where T : IModel, new()
        {
            var type = typeof(T);
            var is_transient = type.GetInterface("ITransientModel") != null;
            if (is_transient) {
                var t = (T)Activator.CreateInstance(typeof(T));
                return t;
            } else {
                lock (model_mutex_) {
                    var t = singleton_models_.Find(
                        e => e.GetType() == typeof(T));
                    if(t == null)
                        t = (ISingletonModel)(new T());
                    singleton_models_.Add(t);
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
            foreach (var model in singleton_models_) {
                var item = model as IDisposable;
                if (item != null)
                    item.Dispose();
            }
            singleton_models_.Clear();
        }

        protected override void DisposeNative()
        {
        }
    }
}