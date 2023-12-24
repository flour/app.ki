namespace AppKi.Business.Messaging.Events;

public class TestMessage : IAnEvent
{
    public Guid Test { get; set; } = Guid.NewGuid();
}