using System.Runtime.Remoting.Messaging;

namespace EPII.Area
{
    //todo: replace CallContext to improve performance
    internal class ContextTable : Table<AreaContext>
    {
        internal static ContextTable CurrentContextTable
        {
            get
            {
                var table = CallContext.LogicalGetData("EPII.Area.ContextTable");
                if (table == null)
                    CallContext.LogicalSetData("EPII.Area.Context", new ContextTable());
                return table as ContextTable;
            }
        }
    }
}
