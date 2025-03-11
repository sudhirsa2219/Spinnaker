using Application.Customer.Queries.GetOrdersByCustomer;

namespace WebApi.Endpoints;

public record GetCustomersByEmailResponse(IEnumerable<CustomerDto> Customer);

public class GetCustomersByEmail : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/customers/Email/{email}", async (string email, ISender sender) =>
        {
            var result = await sender.Send(new GetCustomersByEmailQuery(email));

            var response = result.Adapt<GetCustomersByEmailResponse>();

            return Results.Ok(response);
        })
        .WithName("GetCustomerByEmail")
        .Produces<GetCustomersByEmailResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Customers By Email")
        .WithDescription("Get Customers By Email");
    }
}
