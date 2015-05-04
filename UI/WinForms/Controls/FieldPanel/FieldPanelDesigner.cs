using System.Security.Permissions;
using System.Windows.Forms.Design;

namespace EPII.UI.WinForms
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class FieldPanelDesigner : ControlDesigner
    {

        public FieldPanelDesigner()
        {
        }
    }
}
