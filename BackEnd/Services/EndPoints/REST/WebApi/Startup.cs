using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyConverterService.Interfaces;
using CurrencyConverterService.Services;
using CurrencyLayerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RepositoryModel.Interfaces;
using RepositoryModel.Repositories;
using ServiceModel.Interfaces;
using ServiceModel.Services;
using WebApi.Middleware;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(o => o.AddPolicy("AnyOriginPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyMethod();
            }));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddScoped<ICurrencyRepository>((serviceProvider) =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var currencyLayerServiceConfiguration = configuration.GetSection("CurrencyLayerServiceConfiguration");

                var config = new CurrencyLayerServiceConfig()
                {
                    AccessKey = currencyLayerServiceConfiguration.GetValue<string>("AccessKey"),
                    BaseUrl = currencyLayerServiceConfiguration.GetValue<string>("BaseUrl")
                };

                return new CurrencyLayerRepository(config);
            });

            services.AddScoped<ICurrencyConverterService>((serviceProvider) =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var currencyLayerServiceConfiguration = configuration.GetSection("CurrencyLayerServiceConfiguration");

                var config = new CurrencyLayerServiceConfig()
                {
                    AccessKey = currencyLayerServiceConfiguration.GetValue<string>("AccessKey"),
                    BaseUrl = currencyLayerServiceConfiguration.GetValue<string>("BaseUrl")
                };

                return new CurrencyLayerConverterService(config);
            });

            services.AddScoped<ICurrencyService, CurrencyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AnyOriginPolicy");

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseMvc();
        }
    }
}
