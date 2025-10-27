using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.BAL;
using ProductManagementSystem.BAL.Interfaces;
using ProductManagementSystem.BAL.Services;
using ProductManagementSystem.DAL;
using ProductManagementSystem.DAL.Interfaces;
using ProductManagementSystem.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.

// --- Configure Entity Framework Core with SQL Server ---
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// --- Configure Swagger for API documentation ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- Configure AutoMapper ---
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// --- Configure Dependency Injection for our services and repositories ---
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

// 2. Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();