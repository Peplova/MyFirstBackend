using MyFirstBackend.Business;
using MyFirstBackend.DataLayer;
using MyFirstBackend.Extentions;
using MyFirstBackend.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureApiServices();
builder.Services.ConfigureBllServices();
builder.Services.ConfigureDataBase(builder.Configuration);
builder.Services.ConfigureDalServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseMiddleware<ExceptionHandlingMiddleware>();
