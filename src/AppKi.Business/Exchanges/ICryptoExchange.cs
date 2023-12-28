using AppKi.Commons.Domain.Exchange;
using AppKi.Commons.Models;

namespace AppKi.Business.Exchanges;

public interface ICryptoExchange
{
    Task<ResultList<TickerRate>> GetTickers();
    Task<ResultList<Ohlcv>> GetSpotHistory(DateTime from, DateTime to, string @base, string quoted);
}