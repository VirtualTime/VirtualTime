namespace VirtualTimeLib
{
    using System;

    public interface ITime
    {
        DateTime UtcNow { get; }

        DateTime Now { get; }

        DateTime MinValue { get; }

        DateTime MaxValue { get; }

        DateTime Today { get; }

        DateTime FromFileTime(long value);

        DateTime FromBinary(long dateData);

        DateTime FromFileTimeUtc(long fileTimeUtc);

        DateTime Parse(string s);

        DateTime FromOADate(double s);

        DateTime ParseExact(string s, string format, IFormatProvider formatProvider);

        DateTime SpecifyKind(DateTime value, DateTimeKind kind);

        int Compare(DateTime t1, DateTime t2);

        int DaysInMonth(int year, int month);

        bool Equals(DateTime t1, DateTime t2);

        bool TryParse(string s, out DateTime date);

        bool IsLeapYear(int year);
    }
}