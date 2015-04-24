using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.UI
{
    public interface IWindow
    {
        IView View { get; set; }

        IWindowStyle Style { get; }

        void Show();

        void Hide();

        void Close();
    }
}
