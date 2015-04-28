namespace EPII.UI.WinForms
{
    using EPII.FEA;

    public class Director : IDirector
    {
        public IView Activate(IViewModel viewmodel)
        {
            return null;
        }

        public IView Activate(IViewModel viewmodel, IView view)
        {
            view.Bind(viewmodel);
            return view;
        }

        public IView Activate(IViewModel viewmodel, IView view, IViewHost host)
        {
            view.Bind(viewmodel);
            host.View = view;
            return view;
        }
    }
}
