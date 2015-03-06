using System;

namespace EPII.Code
{
    /// <summary>
    /// short time code
    /// </summary>
    public class STC
    {
        private byte _Year = 2;

        /// <summary>
        /// year log10 period, [1,4]
        /// </summary>
        public byte Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        public STC()
        {
        }

        public string ToText(DateTime time)
        {
            var time_text =
                time.Year.ToString("d4").Substring(4 - _Year, _Year) +
                time.DayOfYear.ToString("d3") +
                ((int)Math.Floor(time.TimeOfDay.TotalSeconds)).ToString("d5");
            return time_text;
        }

        public DateTime FromText(string text, int year)
        {
            var time = new DateTime();
            var year_text =
                year.ToString("d4").Substring(0, 4 - _Year) +
                text.Substring(0, _Year);
            var day_text = text.Substring(_Year, 3);
            var sec_text = text.Substring(_Year + 3, 5);
            time.AddYears(year);
            time.AddDays(int.Parse(day_text));
            time.AddSeconds(int.Parse(sec_text));
            return time;
        }
    }
}