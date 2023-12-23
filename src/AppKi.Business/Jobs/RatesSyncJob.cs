using Quartz;

namespace AppKi.Business.Jobs;

[DisallowConcurrentExecution]
internal class RatesSyncJob : IJob
{
    public RatesSyncJob()
    {
        
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        await Task.Yield();
    }
}