using LifeManage.src.Domain;
using Microsoft.EntityFrameworkCore;

namespace LifeManage.src.Application.StartUp
{
	public static class RepositoriesRegistration
	{
		public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
		{
			var con = configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<LifeEaseDbContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
	}
}
