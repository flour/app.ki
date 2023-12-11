using AppKi.Business.Exchanges;
using AppKi.Business.Exchanges.Internals;
using AppKi.Business.Exchanges.Internals.Crypto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppKi.Business;

public static class BusinessInjections
{
    private static readonly Dictionary<string, Type> CryptoExchanges = new();

    public static IServiceCollection AddBusiness(
        this IServiceCollection services, IConfiguration configuration)
        => services
            .AddScoped<Func<string, ICryptoExchange>>(provider => net =>
                provider.GetRequiredService(CryptoExchanges[net]) as ICryptoExchange
                ?? throw new Exception($"Cannot find any exchange for {net} - missing registration or attribute?"))
            .AddCryptoExchange<GateIo, GateIoSettings>(nameof(GateIo), configuration)
            .AddSingleton<IExchangeFactory, ExchangeFactory>();


    private static IServiceCollection AddCryptoExchange<T, TS>(
        this IServiceCollection services, string name, IConfiguration configuration)
        where T : class, ICryptoExchange
        where TS : BaseExchangeSettings
    {
        CryptoExchanges.TryAdd(name, typeof(T));
        return services
            .Configure<TS>(e => configuration.GetSection($"crypto:{name}").Bind(e))
            .AddScoped<T>();
    }
}