namespace LifeManage.src.Application.StartUp
{
	public static class RepositoriesRegistration
	{
		public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
		{
			return services;
		}
	}
}
