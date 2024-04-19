namespace LifeManage.src.Application.StartUp
{
	public static class ConfigurationExtensions
	{
		public static void AddJsonFile(this IConfigurationBuilder builder)
		{
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

			// Get the root path of the application
			var rootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "src"));

			var appsettingsPath = $"appsettings.{environment}.json";

			builder.AddJsonFile(Path.Combine(rootPath, appsettingsPath), optional: false, reloadOnChange: true);
		}
	}
}
