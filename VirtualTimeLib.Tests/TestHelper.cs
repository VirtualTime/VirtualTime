namespace VirtualTimeLib.Tests
{
    using System;

    public class TestHelper
    {
        public  static string[] CreateReport(double expectedElapsedVirtualTime, DateTime whenTimeStarts, int timeToPassMs, DateTime expectedTime, DateTime virtualTime, double marginOfErrorMs)
        {
            var messages = new string[]
            {
                $"expectedElapsedVirtualTime : {expectedElapsedVirtualTime}",
                $"whenTimeStarts : {whenTimeStarts}",
                $"timeToPassMs : {timeToPassMs}",
                $"expected time is {expectedTime}",
                $"virtualTime is {virtualTime}",
                $"errorMarginMs is {marginOfErrorMs}"
            };
            return messages;
        }

        public static bool AreEqualWithinMarginOfError(DateTime expectedTime, DateTime virtualTime, double errorMarginMs, params string[] reports)
        {
            foreach (string message in reports)
                Console.WriteLine(message);
            double timeDifference = (expectedTime - virtualTime).TotalMilliseconds;
            Console.WriteLine($"timeDifference is {timeDifference}");
            return Math.Abs(timeDifference) <= errorMarginMs;
        }
    }
}