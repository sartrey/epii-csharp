using EPII.UI.WinForms;
using System;
using System.Windows.Forms;

namespace EPII.Test.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var runtime = Runtime.Instance;
            var fea = runtime.Use<FEA.FEAModel>();
            var director = fea.GetDirector<UI.WinForms.Director>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var view = new PersonView();
            var viewmodel = new PersonViewModel();
            view.Bind(viewmodel);

            var window = fea.WindowPool.One<Window>();
            window.View = view;
            window.Open();

            Application.Run();
        }
    }
}
