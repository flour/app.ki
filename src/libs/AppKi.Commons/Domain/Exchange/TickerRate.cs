namespace AppKi.Commons.Domain.Exchange;

public record TickerRate(string Base, string Quoted, double Bid, double Ask);