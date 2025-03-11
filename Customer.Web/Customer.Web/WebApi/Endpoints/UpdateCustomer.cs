using Application.Customer.Commands.Update;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints;

public record UpdateCustomerRequest(CustomerDto Customer);
public record UpdateCustomerResponse(bool IsSuccess);

public class UpdateCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/customers", async ([FromBody] UpdateCustomerRequest request, ISender sender) =>
        {
            //var command = request.Adapt<UpdateCustomerCommand>();
            var command = new UpdateCustomerCommand(request.Customer);

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateCustomerResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateCustomer")
        .Produces<UpdateCustomerResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Customer")
        .WithDescription("Update Customer");
    }
}
