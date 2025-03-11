using Application.Customer.Commands.Create;

namespace WebApi.Endpoints;

public record CreateCustomerRequest(CustomerDto Customer);
public record CreateCustomerResponse(Guid Id);

public class CreateCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/customers", async (CreateCustomerRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateCustomerCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateCustomerResponse>();

            return Results.Created($"/carts/{response.Id}", response);
        })
        .WithName("CreateCustomer")
        .Produces<CreateCustomerResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Customer")
        .WithDescription("Create Customer");
    }
}