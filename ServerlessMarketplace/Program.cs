using Amazon.EventBridge;
using Amazon.SQS;
using Marketplace.Domain.Events;
using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.ExceptionHandler;
using ServerlessMarketplace.Platform.Application;
using ServerlessMarketplace.Platform.Infrastructure.Database.Context;
using ServerlessMarketplace.Platform.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var awsResult = builder.Configuration.GetAWSOptions();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSService<IAmazonEventBridge>();
builder.Services.AddTransient<IMarketplaceAppService, MarketplaceAppService>();
builder.Services.AddTransient<IEventPublisher, EventPublisher>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddDbContext<DataContext>();



builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonSQS>();

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

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
