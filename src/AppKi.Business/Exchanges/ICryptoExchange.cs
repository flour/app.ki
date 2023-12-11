using AppKi.Commons.Domain.Crypto;
using AppKi.Commons.Models;

namespace AppKi.Business.Exchanges;

public interface ICryptoExchange
{
    Task<ResultList<Ohlcv>> GetSpotHistory(DateTime from, DateTime to, string @base, string quoted);
}