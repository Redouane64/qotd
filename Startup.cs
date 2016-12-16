using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using scratch.Services;

namespace scratch
{
    public class Startup
    {
        public static void Main(string[] args)
                        => new WebHostBuilder()
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            /*.UseConfiguration(
                                new ConfigurationBuilder()
                                //.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("hosting.json", optional: true)
                                .AddEnvironmentVariables()
                            .Build())*/
                            .UseKestrel()
                            .UseStartup<Startup>()
                            .Build()
                            .Run();

        public Startup(IHostingEnvironment env)
        {
            
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.AddSingleton(typeof(QOTD));

        }

        public void Configure(IHostingEnvironment env, IApplicationBuilder app, QOTD quoteProvider)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute(name: "default", template: "{controller=QOTD}/{action=Index}/{id?}");
            });
        }

    }
}
