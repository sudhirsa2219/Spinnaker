using Core.Pagination;

namespace Application.Customer.Queries.GetCustomers;
public class GetCustomersHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetCustomersQuery, GetCustomersResult>
{
    public async Task<GetCustomersResult> Handle(GetCustomersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;

        var totalCount = await dbContext.Customers.LongCountAsync(cancellationToken);

        var Carts = await dbContext.Customers
                       .Skip(pageSize * pageIndex)
                       .Take(pageSize)
                       .ToListAsync(cancellationToken);

        return new GetCustomersResult(
            new PaginatedResult<CustomerDto>(
                pageIndex,
                pageSize,
                totalCount,
                Carts.ToCustomerDtoList()));        
    }
}
