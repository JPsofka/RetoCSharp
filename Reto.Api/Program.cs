using Microsoft.EntityFrameworkCore;
using Reto.Domain.Interfaces.Repositories;
using Reto.Domain.Interfaces.Services;
using Reto.Infrastructure.Data;
using Reto.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));



builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        x => x.MigrationsAssembly("Reto.Infrastructure")));




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
