using API.Dotnet_7.Application.Mappings;
using API.Dotnet_7.Application.Services;
using API.Dotnet_7.Application.Services.Interface;
using API.Dotnet_7.Domain.Repositories;
using API.Dotnet_7.Infra.Data.Context;
using API.Dotnet_7.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Dotnet_7.Infra.IoC
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
													options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<IPersonRepository, PersonRepository>();
			return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(typeof(DomainToDTOMappings));
			services.AddScoped<IPersonService, PersonService>();
			return services;
		}
	}
}
