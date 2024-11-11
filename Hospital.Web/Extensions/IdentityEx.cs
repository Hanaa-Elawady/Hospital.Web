using Hospital.Data.Contexts;
using Hospital.Data.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hospital.Web.Extensions
{
    public static class IdentityEx
    {
        public static IServiceCollection AddIdentityConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = services.AddIdentityCore<AppUser>();

            builder.AddRoles<IdentityRole>();
            builder = new IdentityBuilder(builder.UserType, builder.RoleType, builder.Services);

            builder.AddEntityFrameworkStores<HospitalIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
            //.AddDefaultTokenProviders();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
              AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                  ValidateIssuer = false,
                  ValidateAudience = false,
                  ValidateLifetime = true
              });
            return services;
        }

    }
}
