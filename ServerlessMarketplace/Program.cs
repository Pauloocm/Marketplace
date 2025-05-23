using Microsoft.EntityFrameworkCore;
using ServerlessMarketplace.CustomBinder;
using ServerlessMarketplace.Domain.Customers;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.ExceptionHandler;
using ServerlessMarketplace.Platform.Application.Customers;
using ServerlessMarketplace.Platform.Application.Products;
using ServerlessMarketplace.Platform.Infrastructure.Database.Context;
using ServerlessMarketplace.Platform.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new CustomerIdRouteModelBinderProvider()); // Insert at the beginning to prioritize
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IProductAppService, ProductAppService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

builder.Services.AddDbContext<DataContext>(
    options => options.UseNpgsql($"Server=localhost:5433;Database=Product;Username=postgres;Password=root",
        b => b.MigrationsAssembly("ServerlessMarketplace.Migrations")));


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();