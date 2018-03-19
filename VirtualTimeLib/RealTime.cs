namespace VirtualTimeLib
{
    using System;

    class RealTime : ITime
    {
        public DateTime UtcNow => DateTime.UtcNow;

        public DateTime Now => DateTime.Now;

        public DateTime MinValue => DateTime.MinValue;

        public DateTime MaxValue => DateTime.MaxValue;
    }
}