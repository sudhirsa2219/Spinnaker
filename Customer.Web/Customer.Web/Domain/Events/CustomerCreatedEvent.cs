namespace Domain.Events;

public record CustomerCreatedEvent(Customer Customer) : IDomainEvent;
