using Core.Pagination;

namespace Application.Customer.Queries.GetCustomers;

public record GetCustomersQuery(PaginationRequest PaginationRequest) : IQuery<GetCustomersResult>;

public record GetCustomersResult(PaginatedResult<CustomerDto> Customers);