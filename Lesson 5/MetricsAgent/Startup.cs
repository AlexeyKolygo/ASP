using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Entity.DB;
using MetricsAgent.Jobs;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;


namespace MetricsAgent
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MetricsAgent", Version = "v1" });
            });
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbRepository<CpuMetric>, DbRepository<CpuMetric>>();
            services.AddScoped<IDbRepository<DotNetMetric>, DbRepository<DotNetMetric>>();
            services.AddScoped<IDbRepository<HDDMetric>, DbRepository<HDDMetric>>();
            services.AddScoped<IDbRepository<NetworkMetric>, DbRepository<NetworkMetric>>();
            services.AddScoped<IDbRepository<RamMetric>, DbRepository<RamMetric>>();
           
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<CpuMetricJob>();
            services.AddSingleton<RamMetricJob>();
            services.AddSingleton<testJob>();
            services.AddSingleton(new SingletonJobFactory.JobSchedule(
                jobType: typeof(testJob),
                cronExpression: "0/5 * * * * ?"));

            services.AddSingleton(new SingletonJobFactory.JobSchedule(
            jobType: typeof(CpuMetricJob),
             cronExpression: "0/5 * * * * ?")); // запускать каждые 5 секунд
            services.AddSingleton(new SingletonJobFactory.JobSchedule(
             jobType: typeof(RamMetricJob),
            cronExpression: "0/5 * * * * ?"));
            services.AddHostedService<QuartzHostedService>();

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MetricsAgent v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


}
