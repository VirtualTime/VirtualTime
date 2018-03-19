namespace VirtualTimeLib.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;

    // virtual time = (real time - start time ) * speed  of time
    // virtual time elapsed = (speed of time * real time elapsed)

    [TestClass]
    public class when_virtual_time_is_used
    {
        private const double MarginOfErrorMs = 10;

        [TestMethod]
        public void it_should_get_current_time()
        {
            DateTime whenTimeStarts = DateTime.Now;
            int speedOfTimePerMs = 1;

            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            DateTime virtualTime = time.Now;
            DateTime expectedTime = DateTime.Now;
            string[] report = TestHelper.CreateReport(0, whenTimeStarts, 0, expectedTime, virtualTime,MarginOfErrorMs);
            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_get_current_time_in_utc()
        {
            DateTime whenTimeStarts = DateTime.UtcNow;
            int speedOfTimePerMs = 1;

            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            DateTime virtualTime = time.UtcNow;
            DateTime expectedTime = DateTime.UtcNow;
            string[] report = TestHelper.CreateReport(0, whenTimeStarts, 0, expectedTime, virtualTime,MarginOfErrorMs);
            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_get_current_time_after_time_is_passed()
        {
            DateTime whenTimeStarts = DateTime.Now;
            int speedOfTimePerMs = 1;

            int timeToPassMs = 3000;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime virtualTime = time.Now;
            DateTime expectedTime = DateTime.Now;
            string[] report = TestHelper.CreateReport(0, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);
            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_get_current_time_in_utc_after_time_is_passed()
        {
            DateTime whenTimeStarts = DateTime.UtcNow;
            int speedOfTimePerMs = 1;

            int timeToPassMs = 3000;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime virtualTime = time.UtcNow;
            DateTime expectedTime = DateTime.UtcNow;
            string[] report = TestHelper.CreateReport(0, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);
            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_get_current_time_after_time_is_passed2()
        {
            DateTime whenTimeStarts = DateTime.Now;
            int speedOfTimePerMs = 1;

            int timeToPassMs = 3000;

            DateTime expectedTime = DateTime.Now;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime virtualTime = time.Now;
            string[] report = TestHelper.CreateReport(0, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);
            Assert.IsFalse(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_get_current_time_in_utc_after_time_is_passed2()
        {
            DateTime whenTimeStarts = DateTime.UtcNow;
            int speedOfTimePerMs = 1;

            int timeToPassMs = 3000;

            DateTime expectedTime = DateTime.UtcNow;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime virtualTime = time.UtcNow;
            string[] report = TestHelper.CreateReport(0, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);
            Assert.IsFalse(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_make_time_move_faster()
        {
            int speedOfTimePerMs = 1000;
            int timeToPassMs = 3000;
            int expectedElapsedVirtualTime = speedOfTimePerMs * timeToPassMs;
            DateTime whenTimeStarts = DateTime.Now;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime expectedTime = DateTime.Now.AddMilliseconds(expectedElapsedVirtualTime - timeToPassMs);
            DateTime virtualTime = time.Now;
            string[] report = TestHelper.CreateReport(expectedElapsedVirtualTime, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);

            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_make_time_move_faster_in_utc()
        {
            int speedOfTimePerMs = 1000;
            int timeToPassMs = 3000;
            int expectedElapsedVirtualTime = speedOfTimePerMs * timeToPassMs;
            DateTime whenTimeStarts = DateTime.UtcNow;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime expectedTime = DateTime.UtcNow.AddMilliseconds(expectedElapsedVirtualTime - timeToPassMs);
            DateTime virtualTime = time.UtcNow;
            string[] report = TestHelper.CreateReport(expectedElapsedVirtualTime, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);
            Assert.IsTrue(
                TestHelper.AreEqualWithinMarginOfError(
                    expectedTime,
                    virtualTime,
                    MarginOfErrorMs,
                    report
                ));
        }



        [TestMethod]
        public void it_should_make_time_move_slower()
        {
            double speedOfTimePerMs = 1 / 5;
            int timeToPassMs = 3000;
            double expectedElapsedVirtualTime = speedOfTimePerMs * timeToPassMs;
            DateTime whenTimeStarts = DateTime.Now;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime expectedTime = DateTime.Now.AddMilliseconds(expectedElapsedVirtualTime - timeToPassMs);
            DateTime virtualTime = time.Now;
            string[] report = TestHelper.CreateReport(expectedElapsedVirtualTime, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);

            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_make_time_move_slower_in_utc()
        {
            double speedOfTimePerMs = 1 / 5;
            int timeToPassMs = 3000;
            double expectedElapsedVirtualTime = speedOfTimePerMs * timeToPassMs;
            DateTime whenTimeStarts = DateTime.UtcNow;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime expectedTime = DateTime.UtcNow.AddMilliseconds(expectedElapsedVirtualTime - timeToPassMs);
            DateTime virtualTime = time.UtcNow;
            string[] report = TestHelper.CreateReport(expectedElapsedVirtualTime, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);

            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_make_time_move_at_same_rate_as_real_time()
        {
            double speedOfTimePerMs = 1;
            int timeToPassMs = 3000;
            DateTime whenTimeStarts = DateTime.Now;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime expectedTime = DateTime.Now;
            DateTime virtualTime = time.Now;
            string[] report = TestHelper.CreateReport(0, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);

            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }

        [TestMethod]
        public void it_should_make_time_move_at_same_rate_as_real_time_in_utc()
        {
            double speedOfTimePerMs = 1;
            int timeToPassMs = 3000;
            DateTime whenTimeStarts = DateTime.UtcNow;
            ITime time = whenTimeStarts.ToVirtualTime(speedOfTimePerMs);
            Thread.Sleep(timeToPassMs);
            DateTime expectedTime = DateTime.UtcNow;
            DateTime virtualTime = time.UtcNow;
            string[] report = TestHelper.CreateReport(0, whenTimeStarts, timeToPassMs, expectedTime, virtualTime,MarginOfErrorMs);

            Assert.IsTrue(TestHelper.AreEqualWithinMarginOfError(expectedTime, virtualTime, MarginOfErrorMs, report));
        }
    }
}