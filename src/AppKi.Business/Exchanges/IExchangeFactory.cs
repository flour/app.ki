namespace AppKi.Business.Exchanges;

public interface IExchangeFactory
{
    ICryptoExchange GetCrypto(string name);
    List<ICryptoExchange> GetAllCrypto();
}