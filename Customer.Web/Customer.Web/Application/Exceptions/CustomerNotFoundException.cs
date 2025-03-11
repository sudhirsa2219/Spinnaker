using Core.Exceptions;

namespace Application.Exceptions;
public class CustomerNotFoundException(Guid id) : NotFoundException("Customer", id);
