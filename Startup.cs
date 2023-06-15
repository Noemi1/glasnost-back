using glasnost_back.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace glasnost_back
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ModelDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));

            services.AddControllers()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.IgnoreNullValues = true;
                })
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Culture = new CultureInfo("pt-BR", false);
                });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen();

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            //services.AddScoped<ILoggerServices, LoggerServices>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // generated swagger json and swagger ui middleware
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET Core Sign-up and Verification API");
                x.RoutePrefix = String.Empty;
            });

            app.UseRequestLocalization();

            app.UseRouting();

            app.UseCors(option => option
                .SetIsOriginAllowed(x => true)
                .WithOrigins("http://localhost:4100")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            //app.UseMiddleware<ErrorHandlerMiddleware>();
            //app.UseMiddleware<JwtMiddleware>();
            //app.UseMiddleware<EmpresaIdMiddleware>();
            //app.UseMiddleware<LoggerMiddleware>();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
