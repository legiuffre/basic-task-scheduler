public class BackgroundJob : IJob 
{
    public async Task Execute(IJobExecutionContext context)
    {
        await Console.Out.WriteLineAsync("Executing background job");
    }
}
