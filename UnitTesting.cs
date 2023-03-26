using System.Net.NetworkInformation;
using System.Runtime.ExceptionServices;

namespace UnitTesting
{
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

        public static bool JobEqual(IJob job1, IJob job2)
        {
            return (job1.Id == job2.Id) &&
                (job1.TimeReceived == job2.TimeReceived) &&
                (job1.ExecutionTime == job2.ExecutionTime) &&
                (job1.Priority == job2.Priority);
        }

        public static bool JobArrayEqual(IJob[] jobArray1, IJob[] jobArray2)
        {
            if (jobArray1.Length != jobArray2.Length) return false;

            foreach ((IJob job1, IJob job2) in Enumerable.Zip(jobArray1, jobArray2))
                if (!JobEqual(job1, job2)) return false;

            return true;
        }

        public static bool JobCollectionEqual(IJobCollection jobCollection1, IJobCollection jobCollection2) 
        { 
            if (jobCollection1.Count != jobCollection2.Count) return false;

            return JobArrayEqual(jobCollection1.ToArray(), jobCollection2.ToArray());
        }

        public static bool SchedulerEqual(IScheduler scheduler1, IScheduler scheduler2)
        {
            return JobCollectionEqual(scheduler1.Jobs, scheduler2.Jobs);
        }
    }
}