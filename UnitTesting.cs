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
    }
}