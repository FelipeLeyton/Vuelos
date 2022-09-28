namespace GestionVuelos
{
    public class Configuration
    {
        public static IConfiguration AppSetting { get; }
        static Configuration()
        {
            AppSetting = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
        }
    }
}
