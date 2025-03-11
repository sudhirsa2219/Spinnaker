namespace Application.Customer.Queries.GetOrdersByCustomer;

public record GetCustomersByEmailQuery(string email) : IQuery<GetCustomersByEmailResult>;

public record GetCustomersByEmailResult(IEnumerable<CustomerDto> Customer);
