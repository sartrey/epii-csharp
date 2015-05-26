using System;

namespace EPII.Code
{
    /// <summary>
    /// short time code
    /// </summary>
    public class STC
    {
        private byte year_ = 2;

        /// <summary>
        /// year log10 period, [1,4]
        /// </summary>
        public byte Year
        {
            get { return year_; }
            set { year_ = value; }
        }

        public STC()
        {
        }

        public string ToText(DateTime time)
        {
            var time_text =
                time.Year.ToString("d4").Substring(4 - year_, year_) +
                time.DayOfYear.ToString("d3") +
                ((int)Math.Floor(time.TimeOfDay.TotalSeconds)).ToString("d5");
            return time_text;
        }

        public DateTime FromText(string text, int year)
        {
            var time = new DateTime();
            var year_text =
                year.ToString("d4").Substring(0, 4 - year_) +
                text.Substring(0, year_);
            var day_text = text.Substring(year_, 3);
            var sec_text = text.Substring(year_ + 3, 5);
            time.AddYears(year);
            time.AddDays(int.Parse(day_text));
            time.AddSeconds(int.Parse(sec_text));
            return time;
        }
    }
}