using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop_Backend.Models;
using eShop_Backend.Repositories;
using eShop_Backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace eShop_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<eShopContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                    .GetBytes(Configuration["Token"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddCors(options =>
			{
				options.AddPolicy(name: MyAllowSpecificOrigins,
								  builder =>
								  {
									  builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
								  });
			});

            services.AddMvc().AddNewtonsoftJson(options =>
                            {
                                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                            });

            services.AddControllers();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPasswordHandler, PasswordHandler>();
            services.AddScoped<IAuthTokenHandler, AuthTokenHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

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
