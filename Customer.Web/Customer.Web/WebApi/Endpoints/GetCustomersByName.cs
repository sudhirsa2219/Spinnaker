using Application.Customer.Queries.GetCustomersByName;

namespace WebApi.Endpoints;

public record GetCustomersByNameResponse(IEnumerable<CustomerDto> Customer);

public class GetCustomersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/customers/{CustomerName}", async (string CustomerName, ISender sender) =>
        {
            var result = await sender.Send(new GetCustomersByNameQuery(CustomerName));

            var customersList = result.Customers.Adapt<List<CustomerDto>>(); 

            var response = new GetCustomersByNameResponse(customersList);

            return Results.Ok(response);
        })
        .WithName("GetCustomersByName")
        .Produces<GetCustomersByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Customers By Name")
        .WithDescription("Get Customers By Name");
    }
}
