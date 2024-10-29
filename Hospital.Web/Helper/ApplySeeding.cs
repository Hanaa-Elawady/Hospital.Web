using Hospital.Data.Contexts;
using Hospital.Repository.Seeding;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Helper
{
	public class ApplySeeding
	{
		public static async Task ApplySeedingAsync(WebApplication app)
		{
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var loggerFactory = services.GetRequiredService<ILoggerFactory>();

				try
				{
					var context = services.GetRequiredService<HospitalDbContext>();
					await context.Database.MigrateAsync();
					await HospitalContextSeed.SeedAsync(context, loggerFactory);
				}
				catch (Exception ex)
				{
					var logger = loggerFactory.CreateLogger<ApplySeeding>();
					logger.LogError(ex.Message);
				}

			}

		}
	}
}
