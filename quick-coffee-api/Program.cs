using Azure.Identity;
using Microsoft.Azure.Cosmos;
using quick_coffee_api.DbContexts;
using quick_coffee_api.Services.ProductService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// COSMOS DB 
var cosmosEndpoint = new Uri(builder.Configuration["Cosmos:Endpoint"]);
var cosmosTokenCredential = new DefaultAzureCredential();
builder.Services.AddDbContextFactory<QuickCoffeeContext>(optionsBuilder =>
    optionsBuilder.UseCosmos(
        cosmosEndpoint.ToString(),
        cosmosTokenCredential,
        "Quick-Coffee",
        options =>
        {
            options.ConnectionMode(ConnectionMode.Direct);
            options.MaxRequestsPerTcpConnection(20);
            options.MaxTcpConnectionsPerEndpoint(32);
        }));

builder.Services.AddTransient<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();