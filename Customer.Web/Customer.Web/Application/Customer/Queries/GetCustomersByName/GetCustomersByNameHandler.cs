namespace Application.Customer.Queries.GetCustomersByName;
public class GetCustomersByNameHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCustomersByNameQuery, GetCustomerByNameResult>
{
    public async Task<GetCustomerByNameResult> Handle(GetCustomersByNameQuery query, CancellationToken cancellationToken)
    {
        var Customers = await dbContext.Customers
                .Where(o => o.Name.ToLower().Contains(query.Name.ToLower()))
                .OrderBy(o => o.Name)
                .ToListAsync(cancellationToken);
        
        Console.WriteLine($"Customers Found: {Customers.Count}");

        // ✅ Check if the list is actually being converted
        var dtoList = Customers.ToCustomerDtoList();
        Console.WriteLine($"DTO List Count: {dtoList.Count()}");

        return new GetCustomerByNameResult(dtoList);
    }    
}
