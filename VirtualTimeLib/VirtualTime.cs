namespace VirtualTimeLib
{
    using System;

    internal class VirtualTime : ITime
    {
        public VirtualTime(DateTime whenTimeStarts, double speedOfTimePerMs = 1, int marginOfErrorMs = 10)
        {
            this.WhenTimeStarts = whenTimeStarts;
            this.SpeedOfTimePerMs = speedOfTimePerMs;
            this.MarginOfErrorMs = marginOfErrorMs;
            this.InitialTimeUtc = DateTime.UtcNow;
            this.InitialTime = DateTime.Now;
        }

        public DateTime Now => this.GetTime((DateTime.Now - this.InitialTime).TotalMilliseconds);
        public DateTime UtcNow => this.GetTime((DateTime.UtcNow - this.InitialTimeUtc).TotalMilliseconds);

        public DateTime MinValue => DateTime.MinValue;

        public DateTime MaxValue => DateTime.MaxValue;
        private DateTime WhenTimeStarts { get; }

        private double SpeedOfTimePerMs { get; }

        private DateTime InitialTimeUtc { get; }

        private DateTime InitialTime { get; }

        private int MarginOfErrorMs { get; }

        private DateTime GetTime(double eMilliSeconds)
        {
            double elaspsMilliSeconds = this.MarginOfErrorMs==0 ?
                Math.Floor(eMilliSeconds):
                Math.Floor(eMilliSeconds / this.MarginOfErrorMs) * this.MarginOfErrorMs;
            double virtualElapseTime = elaspsMilliSeconds * this.SpeedOfTimePerMs;
            return this.WhenTimeStarts.AddMilliseconds(virtualElapseTime);
        }
    }
}