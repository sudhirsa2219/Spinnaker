
using Application.Customer.Commands.Create;
using Application.Customer.Commands.Delete;
using Application.Data;
using Customer.Unit.Tests.Application.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Unit.Tests.Application.Command
{
    public class DeleteCommandHandlerTests : IClassFixture<ApplicationDbContextFixture>
    {
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly Mock<DbSet<Domain.Models.Customer>> _mockCustomerDbSet;
        private readonly DeleteCustomerHandler _handler;

        public DeleteCommandHandlerTests(ApplicationDbContextFixture fixture)
        {
            _mockDbContext = fixture.MockDbContext;
            _mockCustomerDbSet = fixture.MockCustomerDbSet;
            _handler = new DeleteCustomerHandler(_mockDbContext.Object);
        }
        [Fact]
        public async Task Handle_Should_Return_Result_WhenValidData()
        {
            //implement
        }
    }
}
