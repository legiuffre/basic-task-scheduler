using Quartz;
using Quartz.Impl;

public class JobScheduler
{
    public static async void Start()
    {
        IScheduler scheduler = (IScheduler)StdSchedulerFactory.GetDefaultScheduler();
        await scheduler.Start();
        IJobDetail job = JobBuilder.Create<IDGJob>().Build();
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("IDGJob", "IDG")
            .WithSimpleSchedule(s => s
                .WithRepeatCount(10)
                .WithInterval(TimeSpan.FromSeconds(10)))
            .StartAt(DateTime.UtcNow)
            .WithPriority(1)
            .Build();
        await scheduler.ScheduleJob(job, trigger);
        await scheduler.Shutdown();
        // var schedulerFactory = SchedulerBuilder.Create().Build();
        // var scheduler = await schedulerFactory.GetScheduler();
    }
}