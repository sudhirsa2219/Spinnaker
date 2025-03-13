using Application.Data;
using Domain.ValueObjects;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Unit.Tests.Application.Common
{
    public class AppDbContextFixture : IDisposable
    {
        public IApplicationDbContext DbContext { get; }
        public List<Domain.Models.Customer> CustomerList { get; }

        public AppDbContextFixture()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique name for each test
                .Options;

            DbContext = new ApplicationDbContext(options);
            CustomerList = new List<Domain.Models.Customer>();

            // Seed initial data if necessary (optional)
            SeedData();
        }

        private void SeedData()
        {
            var customers = new List<Domain.Models.Customer>
            {
                Domain.Models.Customer.Create(CustomerId.Of(Guid.NewGuid()), "test1@email.com", "John", "Doe", "+271111111111", "8008101111222", "South Africa"),
                Domain.Models.Customer.Create(CustomerId.Of(Guid.NewGuid()), "test2@email.com", "Jane", "Smith", "+272222222222", "9009101111333", "USA"),
                Domain.Models.Customer.Create(CustomerId.Of(Guid.NewGuid()), "test3@email.com", "Bob", "Brown", "+273333333333", "7011101111444", "UK")
            };

            CustomerList.AddRange(customers); // Add data to the list
            DbContext.Customers.AddRange(customers); // Seed data to in-memory DB
            DbContext.SaveChangesAsync(CancellationToken.None).GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            //DbContext?.Dispose(); // Cleanup InMemory DB context
        }
    }
}
