using EHS_API.DTO;
using EHS_API.Models;
using EHS_API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace EHS_API
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


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
          o.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = true,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,
              ValidIssuer = Configuration["JWT:issuer"],
              IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
          });

            //configuration connection string information
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("EHSconnection")));


            //Resoleve DI
            services.AddScoped<IRepositories<UserDetails>, SellerRepository>();
            services.AddScoped<IRepositories<House>, HouseRepository>();
            services.AddScoped<IRepositories<HouseImage>, HouseImageRepository>();

            services.AddScoped<IGetRepository<UserDetails>, SellerRepository>();
            services.AddScoped<IGetRepository<House>, HouseRepository>();
            services.AddScoped<IAdminRepository<House>, AdminRepository>();
            services.AddScoped<IGetRepository<HouseImage>, HouseImageRepository>();
            services.AddScoped<IGetSellerRepository<House>, SellerRepository>();
            services.AddScoped<ISellerDtoRepository<SellerHouseDto>, SellerRepository>();


            services.AddScoped<ICityRepository<House>, HouseRepository>();
            // services.AddScoped<ICityRepository<House>, HouseRepository>();
            services.AddScoped<IGetRepository<City>, CityRepository>();

            services.AddControllers();
           



            services.Configure<FormOptions>(options => options.MultipartBodyLengthLimit = long.MaxValue);


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EHS_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EHS_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
