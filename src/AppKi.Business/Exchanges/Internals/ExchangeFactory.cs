namespace AppKi.Business.Exchanges.Internals;

internal class ExchangeFactory(Func<string, ICryptoExchange> cryptoExchangeGetter) : IExchangeFactory
{
    internal static readonly Dictionary<string, Type> CryptoExchanges = new();

    public ICryptoExchange GetCrypto(string name) 
        => cryptoExchangeGetter(name);

    public List<ICryptoExchange> GetAllCrypto()
        => CryptoExchanges.Keys.Select(cryptoExchangeGetter).ToList();
}