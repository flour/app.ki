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
        var tasks = cryptos.Select(e => e.GetTickers());
        var result = await Task.WhenAll(tasks);
        await messageBus.PublishAsync(
            new TickerRatesEvent { Rates = result.SelectMany(e => e.Data).ToList() });
    }
}