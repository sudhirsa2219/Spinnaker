using Application.Customer.Commands.Create;
using Application.Customer.Commands.Update;
using Application.Data;
using Application.Dtos;
using Customer.Unit.Tests.Application.Common;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Customer.Unit.Tests.Application.Command
{
    public class UpdateCustomerHandlerTests : IClassFixture<ApplicationDbContextFixture>
    {
        private readonly Mock<IApplicationDbContext> _mockDbContext;
        private readonly UpdateCustomerHandler _handler;
        private readonly CreateCustomerHandler _handlercreate;
        private readonly ApplicationDbContextFixture _fixture;

        public UpdateCustomerHandlerTests(ApplicationDbContextFixture fixture)
        {
            _mockDbContext = fixture.MockDbContext;
            _fixture = fixture; // Keep reference to fixture
            _handler = new UpdateCustomerHandler(_mockDbContext.Object);
            _handlercreate = new CreateCustomerHandler(_mockDbContext.Object);
        }

        [Fact]
        public async Task Handle_Should_Return_Result_WhenValidData()
        {
            // Arrange
            var customerId = new Guid("3c59b697-3e8a-442a-8322-004e9ae51568");
            var cdto = new CustomerDto(customerId, "testname", "testsurname", "testemail@email.com", "+271111111111", "8008101111222", "South Africa");

            var createcmd = new CreateCustomerCommand(cdto);
            var createresult = await _handlercreate.Handle(createcmd, CancellationToken.None);

            var storedCustomer = _fixture.MockDbContext.Object.Customers.FirstOrDefault(c => c.Id.Value == customerId);
            

            var cmd = new UpdateCustomerCommand(cdto);
            var result = await _handler.Handle(cmd, CancellationToken.None);

            // Assert
            _mockDbContext.Verify(db => db.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Exactly(2)); // Once for Create, Once for Update
            Assert.NotNull(result);
            Assert.IsType<UpdateCustomerResult>(result);
        }
    }
}
