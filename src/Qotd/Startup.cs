using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace QOTD
{
	public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.AddSingleton(typeof(Services.QuotesProvider));

        }

        public void Configure(IHostingEnvironment env, IApplicationBuilder app)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

	        app.UseMvcWithDefaultRoute();
        }

    }
}
