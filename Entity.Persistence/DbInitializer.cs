
namespace Entities.Persistence
{
	public class DbInitializer
	{
		public static void Initialize(EntitiesDbContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}
