using Discount.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using Discount.Application.Command.CreateCoupon;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Discount.Application;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger to the application
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services
    .AddApplication()
    .AddInfrastructureData(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add controllers to the services
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
