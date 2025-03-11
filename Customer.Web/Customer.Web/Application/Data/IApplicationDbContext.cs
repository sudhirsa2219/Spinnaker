using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Application.Data;
public interface IApplicationDbContext
{
    DbSet<Domain.Models.Customer> Customers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
