using MultiLocales.Data;
using MultiLocales.Models;
using MultiLocales.Repostories;
using MultiLocales.Services;
using GridMvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MultiLocales
{
    public class Startup
    {
        public static string ConnectionString = "Server=51.145.143.174,1433;Initial Catalog=NORTHWIND;Persist Security Info=False;User ID=user;Password=uSer2019;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public static string Culture = "en-GB";
            //"fr-FR";
            //= "en-US";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NorthwindDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddScoped<IRepository<Order>,BaseRepository<Order>>();
            services.AddScoped<IRepository<OrderVM>, BaseRepository<OrderVM>>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddGridMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
