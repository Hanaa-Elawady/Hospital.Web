using Microsoft.OpenApi.Models;

namespace Hospital.Web.Extensions
{
    public static class SwaggerEx
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Hospital API", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "Enter 'Bearer' followed by a space and your JWT token in the text input below.\nExample: 'Bearer abcdef12345'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };

                options.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securityScheme, Array.Empty<string>() }
                };

                options.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
    }
}
