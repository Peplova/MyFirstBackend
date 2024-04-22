using Microsoft.Extensions.DependencyInjection;
using MyFirstBackend.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBackend.Business;

public static class ConfigureServices
{
    public static void ConfigureBllServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersServices, UsersServices>();
        services.AddScoped<IDevicesServices, DevicesServices>();

    }
}

