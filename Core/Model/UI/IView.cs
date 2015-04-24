using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII.UI
{
    public interface IView
    {
        string Id { get; set; }

        void Bind(IViewModel viewmodel);

        void UpdateViewModel(bool render = true);
    }
}
