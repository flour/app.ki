using AppKi.Business.Exchanges;
using AppKi.Business.Exchanges.Internals;
using AppKi.Business.Exchanges.Internals.Crypto;
using AppKi.Business.Jobs;
using AppKi.Business.Extensions;
using AppKi.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace AppKi.Business;

public static class BusinessInjections
{
    public static IServiceCollection AddBusiness(
        this IServiceCollection services, IConfiguration configuration)
        => services
            // Infrastructure
            .AddDataAccess(configuration)
            
            // Exchanges
            .AddScoped<Func<string, ICryptoExchange>>(provider => net =>
                provider.GetRequiredService(ExchangeFactory.CryptoExchanges[net]) as ICryptoExchange
                ?? throw new Exception($"Cannot find any exchange for {net} - missing registration?"))
            .AddCryptoExchange<GateIo, GateIoSettings>(nameof(GateIo), configuration)
            .AddSingleton<IExchangeFactory, ExchangeFactory>()

            // Jobs
            .AddQuartz(cfg => { cfg.AddJobs<RatesSyncJob>(TimeSpan.FromSeconds(10)); })
            .AddQuartzHostedService(e => e.AwaitApplicationStarted = true);


    private static IServiceCollection AddCryptoExchange<T, TS>(
        this IServiceCollection services, string name, IConfiguration configuration)
        where T : class, ICryptoExchange
        where TS : BaseExchangeSettings
    {
        ExchangeFactory.CryptoExchanges.TryAdd(name, typeof(T));
        return services
            .Configure<TS>(e => configuration.GetSection($"crypto:{name}").Bind(e))
            .AddScoped<T>();
    }
}