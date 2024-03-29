using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AdminDemo.Adapters.ModelsBuilder;
using AdminDemo.Domains.Models;
using AdminDemo.Usecases.EFRepositoriesImpl;
using AdminDemo.Usecases.Interactors;
using AdminDemo.Usecases.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace AdminDemo
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
//            services.Configure<AppSetting>(Configuration.GetSection("QueryService"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddDbContext<mydbContext>(options => { options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")); });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<AdminUseCases, AdminUseCases>();
            services.AddScoped<ITransactionRepository, EFTransactionsRepository>();
            services.AddScoped<IUserRepository, EFUsersRepository>();
            services.AddScoped<ICountryRepository, EFCountryRepository>();
            services.AddScoped<IProvinceRepository, EFProvinceRepositoy>();
            
            services.AddScoped<TransactionBuilder, TransactionBuilder>();
            services.AddScoped<UserBuilder, UserBuilder>();
            services.AddScoped<ProvinceBuilder, ProvinceBuilder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes => { 
                routes.MapRoute(
                    name: "admin",
                    template: "{controller=Home}/{action=Admin}"
                );
            });
        }
    }
}