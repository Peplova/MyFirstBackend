using Microsoft.Extensions.DependencyInjection;
using MyFirstBackend.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.DataLayer;

public static class ConfigureServices
{
    public static void ConfigureDalServices(this IServiceCollection services)
    {
      services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IDevicesRepository, DevicesRepository>();
    }
}
