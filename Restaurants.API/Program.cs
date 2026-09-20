using Microsoft.EntityFrameworkCore;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//We can't directly access the DbContext because it has internal scope,
//but we can access this public method AddInfrastructure
//W ecan just pass a Configuration instance since we may use it to retrieve other configuration data besides connection string 

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
