using System;

namespace EPII.Code
{
    /// <summary>
    /// local unique code
    /// </summary>
    public class LUC
    {
        public const int MaxLength = 9;

        private object _SyncRoot = new object();
        private STC _STC = new STC();
        private int _Spin = 0;

        public LUC()
        {
        }

        public string Next()
        {
            DateTime time;
            lock (_SyncRoot) {
                time = DateTime.Now;
                _Spin = (_Spin == 238327 ? 0 : _Spin + 1);
            }
            return Combine(time, _Spin);
        }

        private string Combine(DateTime time, int spin)
        {
            var time_text = _STC.ToText(time);
            var spin_text = spin.ToString();
            string result =
                RCC.DecToSafe62(time_text).PadLeft(6, '0') +
                RCC.DecToSafe62(spin_text);
            return result;
        }

        public static string Safe62ToDec(string sluc)
        {
            var time_text = sluc.Substring(0, 6);
            var spin_text = sluc.Substring(6);
            var result =
                RCC.Safe62ToDec(time_text).PadLeft(10, '0') +
                RCC.Safe62ToDec(spin_text);
            return result;
        }

        public static string DecToSafe62(string sluc)
        {
            var time_text = sluc.Substring(0, 10);
            var spin_text = sluc.Substring(10);
            var result =
                RCC.DecToSafe62(time_text).PadLeft(6, '0') +
                RCC.DecToSafe62(spin_text);
            return result;
        }
    }
}