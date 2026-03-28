namespace Campus.Models;

public class Registration
{
    public Guid RegistrationId { get; set; } = Guid.NewGuid();

    public Guid EventId { get; set; }

    public Event? Event { get; set; }

    public DateTime RegisteredAt { get; set; } = DateTime.Now;

    public RegistrationStatus Status { get; set; } = RegistrationStatus.Confirmed;
}

public enum RegistrationStatus
{
    Confirmed,
    Cancelled
}
