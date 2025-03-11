using FluentValidation;

namespace Application.Customer.Commands.Update;
public record UpdateCustomerCommand(CustomerDto Cust) : ICommand<UpdateCustomerResult>;

public record UpdateCustomerResult(bool IsSuccess);

public class UpdateCartCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCartCommandValidator()
    {
        RuleFor(x => x.Cust.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(x => x.Cust.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Cust.Email).NotNull().WithMessage("Email is required");
    }
}

