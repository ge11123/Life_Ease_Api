using IdentityManage.src.Domain;
using IdentityManage.src.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityManage.src.Application.Configure
{
	public static class ConfigureRegistration
	{
		public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddIdentityServer()
				.AddInMemoryClients(Config.Clients)
				.AddInMemoryIdentityResources(Config.IdentityResources)
				.AddInMemoryApiScopes(Config.ApiScopes)
				.AddDeveloperSigningCredential()
				.AddAspNetIdentity<ApplicationUser>();

			services.AddControllersWithViews();

		}


	}
}
