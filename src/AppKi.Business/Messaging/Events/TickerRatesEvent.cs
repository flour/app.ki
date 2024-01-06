using AppKi.Commons.Domain.Exchange;

namespace AppKi.Business.Messaging.Events;

public class TickerRatesEvent : IAnEvent
{
    public string Exchange { get; set; }
    public List<TickerRate> Rates { get; set; } = new();
}