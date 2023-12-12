using AppKi.Business.Exchanges;
using AppKi.Business.Exchanges.Internals.Crypto;
using Microsoft.Extensions.Hosting;

namespace AppKi.Business.Jobs;

public class InitJob : BackgroundService
{
    private readonly IExchangeFactory _factory;

    public InitJob(IExchangeFactory factory)
    {
        _factory = factory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var exchange = _factory.GetCrypto(nameof(GateIo));

        var pairs = await exchange.GetPairs();

        await base.StopAsync(stoppingToken);
    }
}