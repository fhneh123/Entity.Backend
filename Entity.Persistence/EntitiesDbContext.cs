using Entities.Application.Interfaces;
using Entities.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Entities.Persistence
{
	public class EntitiesDbContext : DbContext, IEntitiesDbContext
	{
		public DbSet<Entities.Domain.Entity> Entities { get; set; }
		public EntitiesDbContext(DbContextOptions<EntitiesDbContext> options)
			: base(options) { }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new EntityConfiguration());
			base.OnModelCreating(builder);
		}
	}
}
