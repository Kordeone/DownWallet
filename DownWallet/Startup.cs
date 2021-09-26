using DownWallet.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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
using System.Linq;
using DownWallet.Services.MapperProfiles;
using System.Threading.Tasks;
using DownWallet.DataAccess.Repositories;
using DownWallet.DataAccess;
using DownWallet.Utilities;

namespace DownWallet
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
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DownWalletDb"));
            });
            //Services
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IWalletOwnerService, WalletOwnerService>();
            services.AddScoped<IWalletService, WalletService>();

            //Repositories
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IWalletOwnerRepository, WalletOwnerRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();

            //Mappers
            services.AddAutoMapper(typeof(AdminProfile));
            services.AddAutoMapper(typeof(RoleProfile));
            services.AddAutoMapper(typeof(WalletOwnerProfile));
            services.AddAutoMapper(typeof(WalletProfile));

            services.AddFluentEmail("downwallettest@gmail.com")
                .AddRazorRenderer()
                .AddSmtpSender("smtp.google.com", 587, "downwallettest@gmail.com", "dwnwlttst1234");

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DownWallet", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DownWallet v1"));
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
