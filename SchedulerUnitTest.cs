using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class SchedulerUnitTest
    {
        [TestMethod]
        public void TestShortestJobFirst()
        {
            IJobCollection jobs = new JobCollection(10);

            jobs.Add(new Job(jobId: 523, timeReceived: 90, executionTime: 23, priority: 8));
            jobs.Add(new Job(jobId: 966, timeReceived: 46, executionTime: 15, priority: 2));
            jobs.Add(new Job(jobId: 26, timeReceived: 11, executionTime: 50, priority: 5));
            jobs.Add(new Job(jobId: 553, timeReceived: 35, executionTime: 12, priority: 1));
            jobs.Add(new Job(jobId: 346, timeReceived: 79, executionTime: 6, priority: 5));
            jobs.Add(new Job(jobId: 560, timeReceived: 95, executionTime: 47, priority: 2));
            jobs.Add(new Job(jobId: 132, timeReceived: 13, executionTime: 18, priority: 8));
            jobs.Add(new Job(jobId: 741, timeReceived: 92, executionTime: 37, priority: 9));
            jobs.Add(new Job(jobId: 267, timeReceived: 11, executionTime: 50, priority: 5));
            jobs.Add(new Job(jobId: 583, timeReceived: 97, executionTime: 22, priority: 2));

            IScheduler scheduler = new Scheduler(jobs);

            IJob[] expected =
            {
                new Job(jobId: 346, timeReceived: 79, executionTime: 6, priority: 5),
                new Job(jobId: 553, timeReceived: 35, executionTime: 12, priority: 1),
                new Job(jobId: 966, timeReceived: 46, executionTime: 15, priority: 2),
                new Job(jobId: 132, timeReceived: 13, executionTime: 18, priority: 8),
                new Job(jobId: 583, timeReceived: 97, executionTime: 22, priority: 2),
                new Job(jobId: 523, timeReceived: 90, executionTime: 23, priority: 8),
                new Job(jobId: 741, timeReceived: 92, executionTime: 37, priority: 9),
                new Job(jobId: 560, timeReceived: 95, executionTime: 47, priority: 2),
                new Job(jobId: 26, timeReceived: 11, executionTime: 50, priority: 5),
                new Job(jobId: 267, timeReceived: 11, executionTime: 50, priority: 5)
            };

            IJob[] actual = scheduler.ShortestJobFirst();

            Assert.IsTrue(UnitTesting.JobArrayEqual(expected, actual), "ShortestJobFirst failed to sort Jobs by executionTime.");
        }

        [TestMethod]
        public void TestPriority()
        {
            IJobCollection jobs = new JobCollection(10);

            jobs.Add(new Job(jobId: 523, timeReceived: 90, executionTime: 23, priority: 8));
            jobs.Add(new Job(jobId: 966, timeReceived: 46, executionTime: 15, priority: 2));
            jobs.Add(new Job(jobId: 26, timeReceived: 11, executionTime: 50, priority: 5));
            jobs.Add(new Job(jobId: 553, timeReceived: 35, executionTime: 12, priority: 1));
            jobs.Add(new Job(jobId: 346, timeReceived: 79, executionTime: 6, priority: 5));
            jobs.Add(new Job(jobId: 560, timeReceived: 95, executionTime: 47, priority: 2));
            jobs.Add(new Job(jobId: 132, timeReceived: 13, executionTime: 18, priority: 8));
            jobs.Add(new Job(jobId: 741, timeReceived: 92, executionTime: 37, priority: 9));
            jobs.Add(new Job(jobId: 267, timeReceived: 11, executionTime: 50, priority: 5));
            jobs.Add(new Job(jobId: 583, timeReceived: 97, executionTime: 22, priority: 2));

            IScheduler scheduler = new Scheduler(jobs);

            IJob[] expected =
            {
                new Job(jobId: 741, timeReceived: 92, executionTime: 37, priority: 9),
                new Job(jobId: 523, timeReceived: 90, executionTime: 23, priority: 8),
                new Job(jobId: 132, timeReceived: 13, executionTime: 18, priority: 8),
                new Job(jobId: 26, timeReceived: 11, executionTime: 50, priority: 5),
                new Job(jobId: 346, timeReceived: 79, executionTime: 6, priority: 5),
                new Job(jobId: 267, timeReceived: 11, executionTime: 50, priority: 5),
                new Job(jobId: 966, timeReceived: 46, executionTime: 15, priority: 2),
                new Job(jobId: 560, timeReceived: 95, executionTime: 47, priority: 2),
                new Job(jobId: 583, timeReceived: 97, executionTime: 22, priority: 2),
                new Job(jobId: 553, timeReceived: 35, executionTime: 12, priority: 1),
            };

            IJob[] actual = scheduler.Priority();

            Assert.IsTrue(UnitTesting.JobArrayEqual(expected, actual), "Priority failed to sort Jobs by priority.");
        }

        [TestMethod]
        public void TestFirstComeFirstServed()
        {
            IJobCollection jobs = new JobCollection(10);

            jobs.Add(new Job(jobId: 523, timeReceived: 90, executionTime: 23, priority: 8));
            jobs.Add(new Job(jobId: 966, timeReceived: 46, executionTime: 15, priority: 2));
            jobs.Add(new Job(jobId: 26, timeReceived: 11, executionTime: 50, priority: 5));
            jobs.Add(new Job(jobId: 553, timeReceived: 35, executionTime: 12, priority: 1));
            jobs.Add(new Job(jobId: 346, timeReceived: 79, executionTime: 6, priority: 5));
            jobs.Add(new Job(jobId: 560, timeReceived: 95, executionTime: 47, priority: 2));
            jobs.Add(new Job(jobId: 132, timeReceived: 13, executionTime: 18, priority: 8));
            jobs.Add(new Job(jobId: 741, timeReceived: 92, executionTime: 37, priority: 9));
            jobs.Add(new Job(jobId: 267, timeReceived: 11, executionTime: 50, priority: 5));
            jobs.Add(new Job(jobId: 583, timeReceived: 97, executionTime: 22, priority: 2));

            IScheduler scheduler = new Scheduler(jobs);

            IJob[] expected =
            {
                new Job(jobId: 26, timeReceived: 11, executionTime: 50, priority: 5),
                new Job(jobId: 267, timeReceived: 11, executionTime: 50, priority: 5),
                new Job(jobId: 132, timeReceived: 13, executionTime: 18, priority: 8),
                new Job(jobId: 553, timeReceived: 35, executionTime: 12, priority: 1),
                new Job(jobId: 966, timeReceived: 46, executionTime: 15, priority: 2),
                new Job(jobId: 346, timeReceived: 79, executionTime: 6, priority: 5),
                new Job(jobId: 523, timeReceived: 90, executionTime: 23, priority: 8),
                new Job(jobId: 741, timeReceived: 92, executionTime: 37, priority: 9),
                new Job(jobId: 560, timeReceived: 95, executionTime: 47, priority: 2),
                new Job(jobId: 583, timeReceived: 97, executionTime: 22, priority: 2)
            };

            IJob[] actual = scheduler.FirstComeFirstServed();

            Assert.IsTrue(UnitTesting.JobArrayEqual(expected, actual), "FirstComeFirstServed failed to sort Jobs by timeReceived.");
        }
    }
}