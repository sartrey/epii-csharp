namespace EPII.Front
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Director
    {
        private List<Type> _ViewTypes 
            = new List<Type>();

        public Director() 
        {
        }

        private IView<T> TryFindView<T>(T viewmodel)
            where T : IViewModel
        {
            var target = typeof(IView<T>);
            foreach (var type in _ViewTypes) {
                var typex = new TypeEx(type);
                if (typex.HasInterface(target))
                    return (IView<T>)Activator.CreateInstance(type);
            }
            return null;
        }

        internal void SearchViews(Assembly assembly)
        {
            var type = typeof(IView);
            var typex = new TypeEx(type);
            _ViewTypes.AddRange(typex.GetDerivedTypes(assembly));
        }

        public IView<T> Activate<T>(T viewmodel)
            where T : IViewModel
        {
            var view = TryFindView(viewmodel);
            if (view != null) {
                view.Bind(viewmodel);
            }
            return view;
        }
    }
}
