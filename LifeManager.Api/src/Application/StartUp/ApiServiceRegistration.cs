using System.Reflection;

namespace LifeManage.src.Application.StartUp
{
	public static class ApiServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			//services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			//Route設定生成小寫的Url 
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true;
			});

			return services;
		}
	}
}
