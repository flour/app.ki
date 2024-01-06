using AppKi.Business.Exchanges;
using AppKi.Business.Messaging.Events;
using Quartz;
using Wolverine;

namespace AppKi.Business.Jobs;

[DisallowConcurrentExecution]
internal class RatesSyncJob(IExchangeFactory factory, IMessageBus messageBus) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var cryptos = factory.GetAllCrypto();
        var tasks = cryptos.Select(async e => new TickerRatesEvent
        {
            Exchange = e.Name,
            Rates = (await e.GetTickers())?.Data.ToList() ?? []
        });

        var result = await Task.WhenAll(tasks);

        foreach (var anEvent in result)
            await messageBus.PublishAsync(anEvent);
    }
}