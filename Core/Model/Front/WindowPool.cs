namespace EPII.Front
{
    using System.Collections.Generic;

    public class WindowPool
    {
        public static WindowPool Instance 
        {
            get 
            { 
                var runtime = Runtime.Instance;
                var front = runtime.Use<Front.Startup>();
                return front.WindowPool;
            }
        }

        private object sync_mutex_ = new object();
        private List<IWindow> windows_
            = new List<IWindow>();
        private int max_cache_ = 16;

        public void TryRelease() 
        {
            if(windows_.Count > max_cache_)
                windows_.RemoveAll(e => !e.HasView);
        }

        public T One<T>()
            where T : class, IWindow, new()
        {
            foreach (var window in windows_) {
                if (window.HasView)
                    continue;
                var target = window as T;
                if (target != null)
                    return target;
            }
            TryRelease();
            var new_window = new T();
            windows_.Add(new_window);
            return new_window;
        }

        public IWindow Whose(IView view) 
        {
            foreach (var window in windows_) {
                if (window.View == view)
                    return window;
            }
            return null;
        }
    }
}