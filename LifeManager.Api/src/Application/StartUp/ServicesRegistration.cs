using LifeManage.src.Application.Services;
using LifeManage.src.Application.Services.Interfaces;

namespace LifeManage.src.Application.StartUp
{
	public static class ServicesRegistration
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddHttpClient();
			services.AddScoped<IApiServices, ApiServices>();
			services.AddScoped<IWeatherServices, WeatherServices>();

			return services;
		}
	}
}
