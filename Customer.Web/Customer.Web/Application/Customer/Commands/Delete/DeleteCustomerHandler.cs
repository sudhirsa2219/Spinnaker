namespace Application.Customer.Commands.Delete;
public class DeleteCustomerHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteCustomerCommand, DeleteCustomerResult>
{
    public async Task<DeleteCustomerResult> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
    {
        var custId = CustomerId.Of(command.CustomerId);
        var Customer = await dbContext.Customers
            .FindAsync([custId], cancellationToken: cancellationToken);

        if (Customer is null)
        {
            throw new CustomerNotFoundException(command.CustomerId);
        }

        dbContext.Customers.Remove(Customer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteCustomerResult(true);        
    }
}
