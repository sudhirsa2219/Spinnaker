using FluentValidation;

namespace Application.Customer.Commands.Create;

public record CreateCustomerCommand(CustomerDto Customer)
    : ICommand<CreateCustomerResult>;

public record CreateCustomerResult(Guid Id);

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Customer.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Customer.Id).NotNull().WithMessage("CustomerId is required");
    }
}