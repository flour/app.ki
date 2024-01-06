using AppKi.Commons.Domain.Exchange;
using AppKi.Commons.Models;
using Microsoft.Extensions.Options;
using Io.Gate.GateApi.Api;
using Io.Gate.GateApi.Client;

namespace AppKi.Business.Exchanges.Internals.Crypto;

internal class GateIo(IOptions<GateIoSettings> options) : ICryptoExchange
{
    private readonly SpotApi _client = new(new Configuration
    {
        BasePath = options.Value.BaseUrl,
        ApiV4Key = options.Value.ApiKey,
        ApiV4Secret = options.Value.ApiSecret
    });

    public string Name => nameof(GateIo);

    public async Task<ResultList<TickerRate>> GetTickers()
    {
        var rates = await _client.ListTickersAsync();
        return ResultList<TickerRate>.Ok(
            rates.Select(e =>
            {
                if (string.IsNullOrWhiteSpace(e.CurrencyPair))
                    return null;

                var pair = e.CurrencyPair.Split('_');
                if (pair.Length != 2)
                    return null;

                return new TickerRate(
                    pair[0],
                    pair[1],
                    double.Parse(string.IsNullOrWhiteSpace(e.HighestBid) ? e.Last : e.HighestBid),
                    double.Parse(string.IsNullOrWhiteSpace(e.LowestAsk) ? e.Last : e.LowestAsk));
            }).Where(e => e != null));
    }

    public async Task<ResultList<Ohlcv>> GetSpotHistory(
        DateTime from, DateTime to, string @base, string quoted)
    {
        await Task.Yield();
        return ResultList<Ohlcv>.Ok(Enumerable.Empty<Ohlcv>());
    }
}