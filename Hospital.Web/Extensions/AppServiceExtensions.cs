using Hospital.Data.Contexts;
using Hospital.Repository.Interfaces;
using Hospital.Repository.Repositories;
using Hospital.Service.Dto_s.Profiles;
using Hospital.Service.HandleResponse;
using Hospital.Service.Interfaces;
using Hospital.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Web.Extensions
{
	public static class AppServiceExtensions
	{
		public static IServiceCollection AddApllicationService(this IServiceCollection services , ConfigurationManager configuration)
		{
			services.AddDbContext<HospitalDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
			});

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IDrugsService, DrugService>();
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
