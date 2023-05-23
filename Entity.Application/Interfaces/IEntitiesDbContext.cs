using Entities.Domain;
using Microsoft.EntityFrameworkCore;

namespace Entities.Application.Interfaces
{
	public interface IEntitiesDbContext
	{
		DbSet<Entity> Entities { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
