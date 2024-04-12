using ServerlessMarketplace.Domain.Products;
using ServerlessMarketplace.Platform.Application;
using ServerlessMarketplace.Platform.Application.CloudServices;
using ServerlessMarketplace.Platform.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMarketplaceAppService, MarketplaceAppService>();
builder.Services.AddTransient<ISqsService, SqsService>();

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
