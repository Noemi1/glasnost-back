

using glasnost_back.Helpers;
using glasnost_back.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddDbContext<ModelDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"), options => options.EnableRetryOnFailure()));

            services.AddControllers().AddJsonOptions(x =>
            {
                //x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                x.JsonSerializerOptions.IgnoreNullValues = true;
            })
            .AddNewtonsoftJson(x =>
            {
                x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                x.SerializerSettings.Culture = new CultureInfo("pt-BR", false);
            });

            services.AddSwaggerGen();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddHttpContextAccessor();

            services.AddScoped<ICnaeService, CnaeService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IPessoaService, PessoaService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseCors(option => option
                .SetIsOriginAllowed(x => true)
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            //app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
