using AppKi.Commons.Domain.Crypto;
using AppKi.Commons.Models;

namespace AppKi.Business.Exchanges.Internals.Crypto;

internal class GateIo : ICryptoExchange
{
    public async Task<ResultList<Ohlcv>> GetSpotHistory(
        DateTime from, DateTime to, string @base, string quoted)
    {
        await Task.Yield();
        return ResultList<Ohlcv>.Ok(Enumerable.Empty<Ohlcv>());
    }
}