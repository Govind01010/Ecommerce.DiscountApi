using Discount.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger to the application
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddInfrastructureData(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add controllers to the services
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger"; // Set Swagger UI at /swagger/index.html
    });
}

app.Run();
