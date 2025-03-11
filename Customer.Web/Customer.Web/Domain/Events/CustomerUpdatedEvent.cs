namespace Domain.Events;

public record CartUpdatedEvent(Customer Cart) : IDomainEvent;
