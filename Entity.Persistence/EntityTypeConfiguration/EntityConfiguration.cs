using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Persistence.EntityTypeConfiguration
{
	public class EntityConfiguration : IEntityTypeConfiguration<Entities.Domain.Entity>
	{
		public void Configure(EntityTypeBuilder<Entities.Domain.Entity> builder)
		{
			builder.HasKey(x => x.Id);
		}
	}
}
