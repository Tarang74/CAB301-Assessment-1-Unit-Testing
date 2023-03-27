namespace UnitTesting
{
    public enum Parameter
    {
        Id,
        TimeReceived,
        ExecutionTime,
        Priority
    }

    public class UnitTesting
    {
        public static void PrintJobCollection(IJobCollection jobs)
        {
            foreach (IJob job in jobs.ToArray()) Console.WriteLine(job.ToString());
        }

        public static void PrintJobs(IJob[] jobs)
        {
            foreach (IJob job in jobs) Console.WriteLine(job.ToString());
        }

        public static bool JobEqual(IJob job1, IJob job2, Parameter? parameter = null)
        {
            return parameter switch
            {
                Parameter.Id => job1.Id == job2.Id,
                Parameter.TimeReceived => job1.TimeReceived == job2.TimeReceived,
                Parameter.ExecutionTime => job1.ExecutionTime == job2.ExecutionTime,
                Parameter.Priority => job1.Priority == job2.Priority,
                _ => (job1.Id == job2.Id) &&
                     (job1.TimeReceived == job2.TimeReceived) &&
                     (job1.ExecutionTime == job2.ExecutionTime) &&
                     (job1.Priority == job2.Priority)
            };
        }

        public static bool JobArrayEqual(IJob[] jobArray1, IJob[] jobArray2, Parameter? parameter = null)
        {
            if (jobArray1.Length != jobArray2.Length) return false;

            foreach ((IJob job1, IJob job2) in Enumerable.Zip(jobArray1, jobArray2))
                if (!JobEqual(job1, job2, parameter)) return false;

            return true;
        }

        public static bool JobCollectionEqual(IJobCollection jobCollection1, IJobCollection jobCollection2, Parameter? parameter = null)
        {
            if (jobCollection1.Count != jobCollection2.Count) return false;

            return JobArrayEqual(jobCollection1.ToArray(), jobCollection2.ToArray(), parameter);
        }

        public static bool SchedulerEqual(IScheduler scheduler1, IScheduler scheduler2, Parameter? parameter = null)
        {
            return JobCollectionEqual(scheduler1.Jobs, scheduler2.Jobs, parameter);
        }
    }
}