using AppKi.Business.Exchanges.Abstractions;
using AppKi.Commons.Domain.Crypto;
using AppKi.Commons.Models;
using Io.Gate.GateApi.Api;
using Io.Gate.GateApi.Client;
using Microsoft.Extensions.Options;

namespace AppKi.Business.Exchanges.Internals.Crypto;

[Exchange(nameof(GateIo))]
internal class GateIo : ICryptoExchange
{
    private readonly ISpotApiAsync _spot;
    public GateIo(IOptions<GateIoSettings> options)
    {
        _spot = new SpotApi(new Configuration
        {
            BasePath = options.Value.BaseUrl,
        });
    }

    public async Task<ResultList<Pair>> GetPairs()
    {
        var _ = await _spot.ListCurrencyPairsAsync();

        return ResultList<Pair>.Ok(new List<Pair>());
    }

    public async Task<ResultList<Ohlcv>> GetSpotHistory(
        DateTime from, DateTime to, string @base, string quoted)
    {
        await Task.Yield();
        return ResultList<Ohlcv>.Ok(Enumerable.Empty<Ohlcv>());
    }
}