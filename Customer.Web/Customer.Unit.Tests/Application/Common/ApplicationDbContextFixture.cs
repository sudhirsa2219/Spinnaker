using Application.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Unit.Tests.Application.Common
{
    public class ApplicationDbContextFixture : IDisposable
    {
        public Mock<IApplicationDbContext> MockDbContext { get; }
        public Mock<DbSet<Domain.Models.Customer>> MockCustomerDbSet { get; }
        private readonly List<Domain.Models.Customer> _customerList;

        public ApplicationDbContextFixture()
        {
            MockDbContext = new Mock<IApplicationDbContext>();
            _customerList = new List<Domain.Models.Customer>();

            MockCustomerDbSet = new Mock<DbSet<Domain.Models.Customer>>();

            // Convert the list into a queryable object for LINQ support
            var queryableList = _customerList.AsQueryable();

            MockCustomerDbSet.As<IQueryable<Domain.Models.Customer>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            MockCustomerDbSet.As<IQueryable<Domain.Models.Customer>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            MockCustomerDbSet.As<IQueryable<Domain.Models.Customer>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            MockCustomerDbSet.As<IQueryable<Domain.Models.Customer>>().Setup(m => m.GetEnumerator()).Returns(() => queryableList.GetEnumerator());

            // Mock Add to actually store the object in _customerList
            MockCustomerDbSet.Setup(m => m.Add(It.IsAny<Domain.Models.Customer>()))
                .Callback<Domain.Models.Customer>(customer => _customerList.Add(customer));

            // Mock FindAsync to find a customer from _customerList
            MockCustomerDbSet.Setup(m => m.FindAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Guid id) => _customerList.FirstOrDefault(c => c.Id.Value == id));

            MockDbContext.Setup(db => db.Customers).Returns(MockCustomerDbSet.Object);
            MockDbContext.Setup(db => db.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        }

        public void Dispose()
        {
            _customerList.Clear();
        }
    }
}