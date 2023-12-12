namespace AppKi.Commons.Domain.Crypto;

public record Ohlcv(
    DateTime Stamp,
    double Open,
    double High,
    double Low,
    double Close,
    double Volume);