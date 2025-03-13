namespace Application.Customer.Commands.Create;
public class CreateCustomerHandler(IApplicationDbContext dbContext)
    : ICommandHandler<CreateCustomerCommand, CreateCustomerResult>
{
    public async Task<CreateCustomerResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var Customer = CreateNewCustomer(command.Customer);

        dbContext.Customers.Add(Customer);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateCustomerResult(Customer.Id.Value);
    }

    private Domain.Models.Customer CreateNewCustomer(CustomerDto CustDto)
    {        
        var newCustomer = Domain.Models.Customer.Create(
                id: CustomerId.Of(Guid.NewGuid()),
                email: CustDto.Email,
                name: CustDto.Name,
                surname: CustDto.Surname,
                tel:CustDto.Telephone,
                idnum:CustDto.IdNumber,
                country:CustDto.Country
                );
        return newCustomer;
    }
}
