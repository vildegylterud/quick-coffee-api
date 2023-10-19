using System.Reflection;
using Microsoft.EntityFrameworkCore;
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
        services.AddControllers(); 
        //services.AddRazorPages();
        services.AddScoped<IProductService, ProductService>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddServerSideBlazor();
        
        services.Configure<CosmosSettings>(
            Configuration.GetSection(nameof(CosmosSettings)));
        
    
        services.AddDbContext<QuickCoffeeContext>(options =>
            options.UseCosmos(
                Configuration["CosmosSettings:Endpoint"],
                Configuration["CosmosSettings:AccessKey"],
                Configuration["CosmosSettings:DatabaseName"]));
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
        
        //app.MapControllers(); //todo får error ved forsøk på bruk av denne
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
