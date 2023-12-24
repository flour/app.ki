using AppKi.Business.Messaging.Events;

namespace AppKi.Business.Messaging.Consumers;

public class TestMessageHandler : IEventConsumer
{
    public async Task Handle(TestMessage anEvent)
    {
        await Task.Yield();
    }
}

public class TestMessageOtherHandler : IEventConsumer
{
    public async Task Handle(TestMessage anEvent)
    {
        await Task.Yield();
    }
}