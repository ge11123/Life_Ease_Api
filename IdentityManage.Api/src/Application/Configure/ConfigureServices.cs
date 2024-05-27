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

			services.AddIdentity<ApplicationUser, IdentityRole>() // ApplicationUser 用戶實體, IdentityRole 角色實體
				.AddEntityFrameworkStores<ApplicationDbContext>() // 使用 ApplicationDbContext 資料庫
				.AddDefaultTokenProviders();                      // 使用預設 Token 提供者

			services.AddIdentityServer()                                 // 添加 IdentityServer 服務
				.AddInMemoryClients(Config.Clients)                      // 定義與設置哪些客戶端可以與 IdentityServer 通信
				.AddInMemoryIdentityResources(Config.IdentityResources)  // 定義哪些身份資源可以被訪問
				.AddInMemoryApiScopes(Config.ApiScopes)                  // 定義哪些 api 可以被訪問
				.AddDeveloperSigningCredential()                         // 開發環境下使用開發者簽名憑證
				.AddAspNetIdentity<ApplicationUser>();                   // 將 IdentityServer 與 Identity 結合

			services.AddAuthentication("Bearer")
		   .AddJwtBearer("Bearer", options =>
			{
				options.Authority = "https://172.29.60.101,1444"; // IdentityServer 地址
				options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateAudience = false
				};
			});

			services.AddControllers();
			services.AddSwaggerGen();
		}


	}
}
