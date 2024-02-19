using Quartz;

public class IDGJob : IJob
{
    public void Execute(IJobExecutionContext context)
    {
        using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\LauraGiuffre\Documents\Log\IDGLog.txt",true))
        {
            streamWriter.WriteLine(DateTime.Now.ToString());
        }
    }

    Task IJob.Execute(IJobExecutionContext context)
    {
        throw new NotImplementedException();
    }
}
