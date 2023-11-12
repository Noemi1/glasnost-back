using glasnost_back.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Globalization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using glasnost_back.Services;

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
            services.AddDbContext<ModelDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"), options => options.EnableRetryOnFailure()));

            services.AddControllers()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddHttpContextAccessor();

            services.AddScoped<ICnaeService, CnaeService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IPessoaService, PessoaService>();
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
