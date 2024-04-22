namespace LifeManage.src.Application.StartUp
{
	public static class ConfigurationExtensions
	{
		public static void AddJsonFile(this IConfigurationBuilder builder)
		{
			var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

			builder.SetBasePath(Directory.GetCurrentDirectory());

			// Get the root path of the application
			//var rootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "src", "src"));

			var appsettingsEnvPath = $"appsettings.{environment}.json";
			var appsettingsPath = $"appsettings.json";

			builder.AddJsonFile(Path.Combine(appsettingsEnvPath), optional: false, reloadOnChange: true);
			builder.AddJsonFile(Path.Combine(appsettingsPath), optional: false, reloadOnChange: true);
			builder.AddEnvironmentVariables();
		}
	}
}
