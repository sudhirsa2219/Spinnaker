using Application.Customer.Queries.GetCustomers;
using Core.Pagination;
using Customer.Unit.Tests.Application.Common;

namespace Customer.Unit.Tests.Application.Queries
{
    public class GetCustomersHandlerTests : IClassFixture<AppDbContextFixture>
    {
        private readonly AppDbContextFixture _fixture;
        private readonly GetCustomersHandler _handler;

        public GetCustomersHandlerTests(AppDbContextFixture fixture)
        {
            _fixture = fixture;
            _handler = new GetCustomersHandler(_fixture.DbContext); // Using DbContext from fixture
        }

        [Fact]
        public async Task Handle_Should_Return_Paginated_Customers()
        {
            // Arrange
            var paginationRequest = new PaginationRequest();
            var query = new GetCustomersQuery(paginationRequest);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Customers.Data);
            Assert.Equal(3, result.Customers.Data.Count()); // Verify total count
        }
    }
}