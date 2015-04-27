namespace EPII
{
    using System.Diagnostics;

    public class Diagnose
    {
        public static void TraceError(
            string clsid, string method, string message)
        {
            Trace.TraceError(string.Format("EPII::{0}::{1} > {2}",
                clsid, method, message));
        }
    }
}