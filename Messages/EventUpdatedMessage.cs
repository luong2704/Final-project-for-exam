using CommunityToolkit.Mvvm.Messaging.Messages;
using Campus.Models;

namespace Campus.Messages;

public sealed class EventUpdatedMessage : ValueChangedMessage<Event>
{
    public EventUpdatedMessage(Event value) : base(value)
    {
    }
}
