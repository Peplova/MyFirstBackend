namespace MyFirstBackend.Extentions;

public static class ConfigureServices
{
    public static void ConfigureApiServices(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();
    }
}



