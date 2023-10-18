using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using quick_coffee_api.DbContext;
using quick_coffee_api.Services.ProductService;


namespace quick_coffee_api;

public class Startup
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Startup"/> class.
    /// </summary>
    /// <param name="configuration">The configuration information.</param>
    public Startup(IConfiguration configuration) => Configuration = configuration;

    /// <summary>
    /// Gets t configuration instance.
    /// </summary>
    public IConfiguration Configuration { get; }
    
    /// <summary>
    /// Select the services used by your app.
    /// </summary>
    /// <param name="services">The service collection.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages();
        services.AddControllersWithViews(); //changed to views 
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddServerSideBlazor();
        services.Configure<CosmosSettings>(
            Configuration.GetSection(nameof(CosmosSettings)));
        
        services.AddDbContextFactory<QuickCoffeeContext>(
            (IServiceProvider sp, DbContextOptionsBuilder opts) =>
            {
                var cosmosSettings = sp
                    .GetRequiredService<IOptions<CosmosSettings>>()
                    .Value;

                opts.UseCosmos(
                    cosmosSettings.EndPoint,
                    cosmosSettings.AccessKey,
                    cosmosSettings.DatabaseName);
                
            });
        services.AddScoped<IProductService, ProductService>();
        
        
        
    }

    /// <summary>
    /// Configure the selected services.
    /// </summary>
    /// <param name="app">The app builder.</param>
    /// <param name="env">The current environment.</param>
    /// <param name="factory">Context factory.</param>
    /// <param name="cs">The Cosmos settings.</param>
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
        /**
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        }); 
        */
    }
}
