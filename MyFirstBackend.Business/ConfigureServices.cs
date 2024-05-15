using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using MyFirstBackend.Business.Automapping;
using MyFirstBackend.Business.Services;
using MyFirstBackend.Business.Validation;
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
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IDevicesService, DevicesService>();
        services.AddControllers()
           .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginUserRequestsValidator>());

    }
}

