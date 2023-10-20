using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cosmos.Storage.Internal;
using Microsoft.Extensions.Options;
using quick_coffee_api.DbContext;
using quick_coffee_api.Features.Products;


namespace quick_coffee_api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)

    {
        

        services.AddDbContextFactory<QuickCoffeeContext>(options =>
            options.UseCosmos(
                Configuration["CosmosDb:Endpoint"],
                Configuration["CosmosDb:AccessKey"],
                Configuration["CosmosDb:DatabaseName"]));
        
        services.AddTransient<IProductService, ProductService>();
        services.AddControllers(); 
        services.AddRazorPages();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddServerSideBlazor();

    }
    
    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IDbContextFactory<QuickCoffeeContext> factory,
        IOptions<CosmosSettings> cs)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseExceptionHandler("/Error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        
        //app.MapControllers(); 
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        }); 
        
    }
}
