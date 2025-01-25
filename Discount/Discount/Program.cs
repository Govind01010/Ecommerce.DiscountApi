using Discount.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add Swagger to the application
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddInfrastructureData(builder.Configuration.GetConnectionString("DefaultConnection"));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
