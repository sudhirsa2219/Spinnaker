namespace Application.Customer.Commands.Update;
public class UpdateCustomerHandler(IApplicationDbContext dbContext)
    : ICommandHandler<UpdateCustomerCommand, UpdateCustomerResult>
{
    public async Task<UpdateCustomerResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
    {
        var custId = CustomerId.Of(command.Cust.Id);
        var Customer = await dbContext.Customers
            .FindAsync([custId], cancellationToken: cancellationToken);

        if (Customer is null)
        {
            throw new CustomerNotFoundException(command.Cust.Id);
        }

        Customer.UpdateDetails(command.Cust.Name, command.Cust.Surname, command.Cust.Email, command.Cust.Telephone, command.Cust.IdNumber, command.Cust.Country);

        //var updatedCust = Domain.Models.Customer.Create(Customer.Id, command.Cust.Name, command.Cust.Surname,command.Cust.Email,command.Cust.Telephone, command.Cust.IdNumber, command.Cust.Country );


        dbContext.Customers.Update(Customer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCustomerResult(true);        
    }
}
