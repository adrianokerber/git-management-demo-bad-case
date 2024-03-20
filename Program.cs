using Microsoft.AspNetCore.Mvc;
using projeto_ruim.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Register Endpoints:
app.RegisterEndpointGetWeatherForecast();

app.MapGet("/current-degrees/{where}", ([FromRoute] string where, DateTimeOffset when) =>
        new {
            when,
            city = where,
            temperatureC = "38.5 C°"
        }
    ).WithName("GetCurrentTemperature")
    .WithOpenApi();

app.Run();
