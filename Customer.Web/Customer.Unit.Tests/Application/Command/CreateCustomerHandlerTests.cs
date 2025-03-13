using Application.Customer.Commands.Create;
using Application.Data;
using Application.Dtos;
using Customer.Unit.Tests.Application.Common;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Customer.Unit.Tests.Application.Command
{
    public class CreateCustomerHandlerTests : IClassFixture<ApplicationDbContextFixture>
    {
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly Mock<DbSet<Domain.Models.Customer>> _mockCustomerDbSet;
        private readonly CreateCustomerHandler _handler;

        public CreateCustomerHandlerTests(ApplicationDbContextFixture fixture)
        {
            _mockDbContext = fixture.MockDbContext;
            _mockCustomerDbSet = fixture.MockCustomerDbSet;
            _handler = new CreateCustomerHandler(_mockDbContext.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_Result_WhenValidData()
        {
            CustomerDto cdto = new CustomerDto(Guid.NewGuid(), "testname","testsurname","testemail@email.com","+271111111111","8008101111222", "South Africa");
            var cmd = new CreateCustomerCommand(cdto);

            var result = await _handler.Handle(cmd, CancellationToken.None);

            // Assert
            _mockCustomerDbSet.Verify(m => m.Add(It.IsAny<Domain.Models.Customer>()), Times.Once);
            _mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

            Assert.NotNull(result);
            Assert.IsType<CreateCustomerResult>(result);
        }
    }
}
