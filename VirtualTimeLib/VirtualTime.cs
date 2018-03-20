namespace VirtualTimeLib
{
    using System;

    class VirtualTime : ITime
    {
        public VirtualTime(DateTime whenTimeStarts, double speedOfTimePerMs = 1, int marginOfErrorMs = 10)
        {
            this.WhenTimeStarts = whenTimeStarts;
            this.SpeedOfTimePerMs = speedOfTimePerMs;
            this.MarginOfErrorMs = marginOfErrorMs;
            this.InitialTimeUtc = DateTime.UtcNow;
            this.InitialTime = DateTime.Now;
        }

        public VirtualTime()
        {
            this.UseRealTime = true;
        }

        public bool UseRealTime { get; set; }

        public DateTime Now => this.GetVirtualTime(DateTime.Now);

        public DateTime UtcNow =>  this.GetVirtualTime(DateTime.UtcNow,false,true);

        public DateTime Today => this.GetVirtualTime(DateTime.Today);

      // public DateTime GetVirtualTimeEquivalent(DateTime dateTime) => GetVirtualTime(dateTime,true);

        DateTime GetVirtualTime(DateTime time, bool force = false,bool isUtc=false)
        {
            if (UseRealTime && !force)
                return time;

            double elasped = (time - (isUtc ? InitialTimeUtc : this.InitialTime)).TotalMilliseconds;
            double elaspsMilliSeconds = this.MarginOfErrorMs == 0 ? Math.Floor(elasped) : Math.Floor(elasped / this.MarginOfErrorMs) * this.MarginOfErrorMs;
            double virtualElapseTime = elaspsMilliSeconds * this.SpeedOfTimePerMs;
            return this.WhenTimeStarts.AddMilliseconds(virtualElapseTime);
        }
        public DateTime FromFileTime(long value)
        {
            return DateTime.FromFileTime(value);
        }

        public DateTime FromBinary(long dateData)
        {
            return DateTime.FromBinary(dateData);
        }

        public DateTime FromFileTimeUtc(long fileTimeUtc)
        {
            return DateTime.FromFileTimeUtc(fileTimeUtc);
        }

        public DateTime Parse(string s)
        {
            return DateTime.Parse(s);
        }

        public DateTime FromOADate(double s)
        {
            return DateTime.FromOADate(s);
        }

        public DateTime ParseExact(string s, string format, IFormatProvider formatProvider)
        {
            return DateTime.ParseExact(s, format, formatProvider);
        }

        public DateTime SpecifyKind(DateTime value, DateTimeKind kind)
        {
            return DateTime.SpecifyKind(value, kind);
        }

        public int Compare(DateTime t1, DateTime t2)
        {
            return DateTime.Compare(t1, t2);
        }

        public int DaysInMonth(int year, int month)
        {
            return DateTime.DaysInMonth(year, month);
        }

        public bool Equals(DateTime t1, DateTime t2)
        {
            return DateTime.Equals(t1, t2);
        }

        public bool TryParse(string s, out DateTime date)
        {
            return DateTime.TryParse(s, out date);
        }

        public bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        public DateTime MinValue => DateTime.MinValue;

        public DateTime MaxValue => DateTime.MaxValue;

        #region MyRegion

        DateTime WhenTimeStarts { get; }

        double SpeedOfTimePerMs { get; }

        DateTime InitialTimeUtc { get; }

        DateTime InitialTime { get; }

        int MarginOfErrorMs { get; }



        #endregion
    }
}