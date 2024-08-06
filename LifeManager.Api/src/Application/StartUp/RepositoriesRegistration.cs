using LifeManage.src.Domain;
using LifeManage.src.Infrastructure.Repositories;
using LifeManage.src.Infrastructure.Repositories.Interfaces;
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


			services.AddScoped<ITodoRepository, TodoRepository>();
			services.AddScoped<ISidebarMenuRepository, SidebarMenuRepository>();
			services.AddScoped<IMonthlyTasksRepository, MonthlyTasksRepository>();
			services.AddScoped<ILedgerTransactionRepository, LedgerTransactionRepository>();
			services.AddScoped<ILedgerCategoryRepository, LedgerCategoryRepository>();
			services.AddScoped<IStoreRepository, StoreRepository>();

			return services;
		}
	}
}
