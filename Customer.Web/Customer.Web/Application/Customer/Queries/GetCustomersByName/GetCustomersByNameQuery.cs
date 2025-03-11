namespace Application.Customer.Queries.GetCustomersByName;

public record GetCustomersByNameQuery(string Name) : IQuery<GetCustomerByNameResult>;

public record GetCustomerByNameResult(IEnumerable<CustomerDto> Customers);