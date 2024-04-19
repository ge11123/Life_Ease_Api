namespace LifeManage.src.Application.StartUp
{
	public static class ConfigurationExtensions
	{
		public static void AddJsonFile(this IConfigurationBuilder builder)
		{
			var rootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "src"));
			builder.AddJsonFile(Path.Combine(rootPath, "appsettings.json"), optional: false, reloadOnChange: true);
		}
	}
}
