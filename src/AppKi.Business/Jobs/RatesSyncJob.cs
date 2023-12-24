using AppKi.Business.Messaging.Events;
using Quartz;
using Wolverine;

namespace AppKi.Business.Jobs;

[DisallowConcurrentExecution]
internal class RatesSyncJob : IJob
{
    private readonly IMessageBus _messageBus;

    public RatesSyncJob(IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }
    
    public Task Execute(IJobExecutionContext context)
    {
        return _messageBus.PublishAsync(new TestMessage()).AsTask();
    }
}