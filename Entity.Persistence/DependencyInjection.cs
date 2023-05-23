using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entities.Application.Interfaces;

namespace Entities.Persistence
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration["DbConnection"];
			services.AddDbContext<EntitiesDbContext>(options =>
			{
				options.UseSqlite(connectionString);
			});

			services.AddScoped<IEntitiesDbContext, EntitiesDbContext>();
			return services;
		}
	}
}
