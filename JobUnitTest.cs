using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class JobUnitTest
    {
        [TestMethod]
        public void TestValidId()
        {
            new Job(1, 1, 1, 1);
            new Job(999, 1, 1, 1);
        }

        [TestMethod]
        public void TestValidTimeReceived()
        {
            new Job(1, 1, 1, 1);
        }

        [TestMethod]
        public void TestValidExecutionTime()
        {
            new Job(1, 1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Job.Id < 1 was inappropriately allowed.")]
        public void TestInvalidId1()
        {
            new Job(0, 1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Job.Id > 999 was inappropriately allowed.")]
        public void TestInvalidId2()
        {
            new Job(1000, 1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Job.TimeReceived <= 0 was inappropriately allowed.")]
        public void TestInvalidTimeReceived()
        {
            new Job(1, 0, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Job.ExecutionTime <= 0 was inappropriately allowed.")]
        public void TestInvalidExecutionTime()
        {
            new Job(1, 1, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Job.Priority < 1 was inappropriately allowed.")]
        public void TestInvalidPriority1()
        {
            new Job(1, 1, 1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Job.Priority > 9 was inappropriately allowed.")]
        public void TestInvalidPriority2()
        {
            new Job(1, 1, 1, 10);
        }
    }
}