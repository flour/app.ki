namespace AppKi.Business.Exchanges.Internals;

internal class ExchangeFactory : IExchangeFactory
{
    private readonly Func<string, ICryptoExchange> _cryptoExchangeGetter;

    public ExchangeFactory(
        Func<string, ICryptoExchange> cryptoExchangeGetter)
    {
        _cryptoExchangeGetter = cryptoExchangeGetter;
    }

    public ICryptoExchange GetCrypto(string name) => _cryptoExchangeGetter(name);

    public List<ICryptoExchange> GetAllCrypto()
    {
        throw new NotImplementedException();
    }
}