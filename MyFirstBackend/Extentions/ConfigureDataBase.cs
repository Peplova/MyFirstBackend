using Microsoft.EntityFrameworkCore;
using MyFirstBackend.DataLayer;

namespace MyFirstBackend.Extentions;

public static class DataBaseExtentions
{
    public static void ConfigureDataBase(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<BlackBookContext>(
           options => options
               .UseNpgsql(configurationManager.GetConnectionString("MypConnection"))
               .UseSnakeCaseNamingConvention()
           );
    }
}
