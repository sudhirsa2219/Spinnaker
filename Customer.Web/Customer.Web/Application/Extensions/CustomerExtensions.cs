namespace Application.Extensions;
public static class CustomerExtensions
{
    public static IEnumerable<CustomerDto> ToCustomerDtoList(this IEnumerable<Domain.Models.Customer> Cust)
    {
        return Cust.Select(c => new CustomerDto(
            Id: c.Id.Value,
            Email: c.Email,
            Name: c.Name,
            Surname:c.Surname,
            Telephone:c.TelephoneNumber,
            IdNumber:c.IdNumber,
            Country:c.Country
        ));
    }

    public static CustomerDto ToCustomerDto(this Domain.Models.Customer Cust)
    {
        return new CustomerDto(
                    Id: Cust.Id.Value,
                    Email: Cust.Email,
                    Name: Cust.Name,
                    Surname: Cust.Surname,
                    Telephone: Cust.TelephoneNumber,
                    IdNumber: Cust.IdNumber,
                    Country: Cust.Country
                );
    }
}
