using FluentValidation;
using FluentValidation.AspNetCore;
using MyFirstBackend.Business;
using MyFirstBackend.Business.Automapping;
using MyFirstBackend.Business.Validation;
using MyFirstBackend.DataLayer;
using MyFirstBackend.Extentions;
using MyFirstBackend.Middlewares;
using Serilog;
try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Logging.ClearProviders();
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
    

    // Add services to the container.

    builder.Services.ConfigureApiServices(builder.Configuration);
    builder.Services.ConfigureBllServices();
    builder.Services.ConfigureDalServices();
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
    builder.Services.AddFluentValidationAutoValidation()
               .AddFluentValidationClientsideAdapters()
               .AddValidatorsFromAssemblyContaining<UserCreateRequestValidation>();
    builder.Host.UseSerilog();             ;

    var app = builder.Build();
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsProduction())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
   
    Log.Information("Running app");
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex.Message);
}
finally
{
    Log.Information("App stopped.");
    Log.CloseAndFlush();
}   