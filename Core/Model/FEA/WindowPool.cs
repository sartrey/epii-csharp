using System.Collections.Generic;

namespace EPII.FEA
{
    public class WindowPool
    {
        private object _SyncRoot = new object();
        private List<IWindow> _Windows
            = new List<IWindow>();
        private int _MaxCache = 0;

        public T One<T>()
            where T : class, IWindow, new()
        {
            foreach (var window in _Windows) {
                if (window.HasView)
                    continue;
                if (window is T)
                    return window as T;
            }
            Clear();
            var new_window = new T();
            _Windows.Add(new_window);
            return new_window;
        }

        public void Clear() 
        {
            if(_Windows.Count > _MaxCache)
                _Windows.RemoveAll(e => !e.HasView);
        }
    }
}