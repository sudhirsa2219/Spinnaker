using FluentValidation;

namespace Application.Customer.Commands.Delete;

public record DeleteCustomerCommand(Guid CustomerId) : ICommand<DeleteCustomerResult>;

public record DeleteCustomerResult(bool IsSuccess);

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("CartId is required");
    }
}
