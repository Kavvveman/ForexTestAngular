using Microsoft.AspNetCore.Builder;

namespace ForexTestAngular
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularApp",
                    builder =>
                    {
                        builder.WithOrigins("htttps://localhost:44481")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddHttpClient();
           // services.

            // Other service configurations...
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("AllowAngularApp");
            app.UseRouting();
            app.UseHttpsRedirection();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
