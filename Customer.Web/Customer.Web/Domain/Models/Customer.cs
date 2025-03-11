namespace Domain.Models;
public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public string Surname { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string TelephoneNumber { get; private set; } = default!;
    public string IdNumber { get; private set; } = default!;
    public string Country { get; private set; } = default!;

    public static Customer Create(CustomerId id, string name, string surname, string email, string tel, string idnum, string country)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(surname);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(tel);
        ArgumentException.ThrowIfNullOrWhiteSpace(idnum);
        ArgumentException.ThrowIfNullOrWhiteSpace(country);

        var customer = new Customer
        {
            Id = id,
            Name = name,
            Surname = surname,
            Email = email,
            TelephoneNumber = tel,
            IdNumber = idnum,
            Country = country
        };

        return customer;
    }

    public void UpdateDetails(string name, string surname, string email, string telephone, string idNumber, string country)
    {
        Name = name;
        Surname = surname;
        Email = email;
        TelephoneNumber = telephone;
        IdNumber = idNumber;
        Country = country;
    }
}
