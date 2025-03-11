namespace Application.Customer.Queries.GetOrdersByCustomer;
public class GetCustomersByEmailHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCustomersByEmailQuery, GetCustomersByEmailResult>
{
    public async Task<GetCustomersByEmailResult> Handle(GetCustomersByEmailQuery query, CancellationToken cancellationToken)
    {
        var Carts = await dbContext.Customers
                        .Where(o => o.Email == query.email)
                        .OrderBy(o => o.Name)
                        .ToListAsync(cancellationToken);

        return new GetCustomersByEmailResult(Carts.ToCustomerDtoList());        
    }
}
