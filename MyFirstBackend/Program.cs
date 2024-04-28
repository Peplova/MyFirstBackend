using MyFirstBackend.Business;
using MyFirstBackend.DataLayer;
using MyFirstBackend.Extentions;
using MyFirstBackend.Middlewares;
using Serilog;
try
{
    var builder = WebApplication.CreateBuilder(args);
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();
    

    // Add services to the container.

    builder.Services.ConfigureApiServices();
    builder.Services.ConfigureBllServices();
    builder.Services.ConfigureDataBase(builder.Configuration);
    builder.Services.ConfigureDalServices();
    builder.Host.UseSerilog();             ;

    var app = builder.Build();
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseSerilogRequestLogging();

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