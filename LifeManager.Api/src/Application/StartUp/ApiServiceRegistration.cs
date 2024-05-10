using FluentValidation;
using LifeManage.src.Application.Behavior;
using MediatR;
using System.Reflection;
using System.Security.Claims;

namespace LifeManage.src.Application.StartUp
{
	public static class ApiServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			//Route設定生成小寫的Url 
			services.AddRouting(options =>
			{
				options.LowercaseUrls = true;
			});

			services.AddMemoryCache();

			return services;
		}

		public static IServiceCollection AddAuth(this IServiceCollection services)
		{
			services.AddScoped<ClaimsPrincipal>(s =>
				s.GetService<IHttpContextAccessor>().HttpContext.User);

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			return services;
		}

	}
}
