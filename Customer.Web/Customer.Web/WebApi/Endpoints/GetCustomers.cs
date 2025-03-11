using Application.Customer.Queries.GetCustomers;
using Core.Pagination;

namespace WebApi.Endpoints;

public record GetCustomerResponse(PaginatedResult<CustomerDto> Customers);

public class GetCustomers : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/customers", async ([AsParameters] PaginationRequest request, ISender sender) =>
        {
            var result = await sender.Send(new GetCustomersQuery(request));

            var response = result.Adapt<GetCustomerResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCustomers")
        .Produces<GetCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Customers")
        .WithDescription("Get Customers");
    }
}
