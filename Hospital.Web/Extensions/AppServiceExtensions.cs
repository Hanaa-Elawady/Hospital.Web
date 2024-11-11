using Hospital.Data.Contexts;
using Hospital.Data.Entities.Identity;
using Hospital.Repository.Interfaces;
using Hospital.Repository.Repositories;
using Hospital.Service.Dto_s.Profiles;
using Hospital.Service.HandleResponse;
using Hospital.Service.Interfaces;
using Hospital.Service.Profiles;
using Hospital.Service.Services;
using Hospital.Service.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hospital.Web.Extensions
{
    public static class AppServiceExtensions
    {
        public static IServiceCollection AddApllicationService(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddIdentityConfig(configuration);
            services.AddDbContext<HospitalDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddDbContext<HospitalIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AuthConnection"));
            });




            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDrugsService, DrugService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddAutoMapper(typeof(OrderProfile));
            services.AddAutoMapper(typeof(DrugProfile));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                                .Where(model => model.Value?.Errors.Count > 0)
                                .SelectMany(model => model.Value?.Errors)
                                .Select(error => error.ErrorMessage)
                                .ToList();


                    var errorResponse = new ValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });

            return services;

        }
    }
}
