using FluentValidation;
using Lab_KPZ_3.CQRS.Users.Queries;
using Lab_KPZ_3.Data;
using Lab_KPZ_3.Infrastructure;
using Lab_KPZ_3.Infrastructure.ExcaptionsHandling.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Lab_KPZ_3
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lab_KPZ_3", Version = "v1" });
            });

            services.AddDbContext<CarpentryShopDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("Default")));

            services.AddMediatR(typeof(GetUsers).Assembly);
            AssemblyScanner.FindValidatorsInAssembly(typeof(GetUsers).Assembly)
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehaviour<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab_KPZ_3 v1"));
            }

            app.UseHttpsRedirection();

            app.UseCustomExceptionHandler();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
