namespace VirtualTimeLib
{
    using System;

    public interface ITime
    {
        DateTime UtcNow { get; }

        DateTime Now { get; }

        DateTime MinValue { get; }

        DateTime MaxValue { get; }
    }
}