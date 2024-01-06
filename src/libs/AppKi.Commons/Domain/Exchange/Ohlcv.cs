namespace AppKi.Commons.Domain.Exchange;

public record Ohlcv(double Open, double High, double Low, double Close, double Volume, DateTime Stamp);