using Hospital.Data.Contexts;
using Hospital.Data.Entities.Identity;
using Hospital.Repository.Seeding;
using Microsoft.AspNetCore.Identity;
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
                    var UserMangeer = services.GetRequiredService<UserManager<AppUser>>();
                    var Rolemanger = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await context.Database.MigrateAsync();
                    await HospitalContextSeed.SeedAsync(context, loggerFactory);
                    await AppUserSeeding.SeedUserAsync(UserMangeer);
                    await AppUserSeeding.SeedRolesAsync(Rolemanger);
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
