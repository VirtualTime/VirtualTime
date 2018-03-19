namespace VirtualTimeLib
{
    using System;

    public static class TimeFactory
    {
        /// <summary>
        /// Get virtual time from  DateTime.UtcNow reference point
        /// </summary>
        /// <param name="speedOfTimePerMs">at value more than 1 time goes faster. At less then 1 time goes slower. At 0 time stands still </param>
        /// <param name="marginOfErrorMs">To what degree is the virtual time correct</param>
        /// <returns></returns>
        public static ITime GetVirtualTimeFromNowUtc(
            double speedOfTimePerMs = 1,
            int marginOfErrorMs = 10)
        {
            return DateTime.UtcNow.ToVirtualTime(
                speedOfTimePerMs,
                marginOfErrorMs);
        }
        /// <summary>
        /// Get virtual time from  DateTime.Now reference point
        /// </summary>
        /// <param name="speedOfTimePerMs">at value more than 1 time goes faster. At less then 1 time goes slower. At 0 time stands still </param>
        /// <param name="marginOfErrorMs">To what degree is the virtual time correct</param>
        /// <returns></returns>
        public static ITime GetVirtualTimeFromNow(
            double speedOfTimePerMs = 1,
            int marginOfErrorMs = 10)
        {
            return DateTime.Now.ToVirtualTime(
                speedOfTimePerMs,
                marginOfErrorMs);
        }

        /// <summary>
        /// Get virtual time from supplied time reference point
        /// </summary>
        /// <param name="startTime">The reference time from which the elapsed time is computed</param>
        /// <param name="speedOfTimePerMs">at value more than 1 time goes faster. At less then 1 time goes slower. At 0 time stands still </param>
        /// <param name="marginOfErrorMs">To what degree is the virtual time correct</param>
        /// <returns></returns>
        public static ITime ToVirtualTime(
            this DateTime startTime,
            double speedOfTimePerMs = 1,
            int marginOfErrorMs = 10)
        {
            return new VirtualTime(startTime, speedOfTimePerMs, marginOfErrorMs);
        }

        /// <summary>
        /// A wrapper arround System.DateTime
        /// </summary>
        /// <returns></returns>
        public static ITime GetRealTime()
        {
            return new RealTime();
        }
    }
}