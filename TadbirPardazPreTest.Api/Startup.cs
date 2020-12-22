using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TadbirPardazPreTest.Persistance;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using TadbirPardazPreTest.ServiceContract.Base;
using TadbirPardazPreTest.Domain;
using TadbirPardazPreTest.DataContract;
using TadbirPardazPreTest.ServiceImplementation;
using TadbirPardazPreTest.ServiceContract;
using TadbirPardazPreTest.Service.Core;
using TadbirPardazPreTest.DomainService;
using TadbirPardazPreTest.Persistance.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TadbirPardazPreTest.Api
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                                           .AddJwtBearer(options =>
                                           {
                                               options.TokenValidationParameters = new TokenValidationParameters
                                               {
                                                   ValidateIssuer = true,
                                                   ValidateAudience = true,
                                                   ValidateLifetime = true,
                                                   ValidateIssuerSigningKey = true,
                                                   ValidIssuer = Configuration["Jwt:Issuer"],
                                                   ValidAudience = Configuration["Jwt:Issuer"],
                                                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                                               };
                                           });
            services.AddScoped<IEntityMapper<User, UserDto>, UserMapper>();
            services.AddTransient<IUserApplicationService, UserApplicationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddControllers();
            services.AddDbContext<TadbirDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                        .Replace("|DataDirectory|",
                            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "app_data")),
                    serverDbContextOptionsBuilder =>
                    {
                        var minutes = (int)TimeSpan.FromMinutes(3).TotalSeconds;
                        serverDbContextOptionsBuilder.CommandTimeout(minutes);
                        serverDbContextOptionsBuilder.EnableRetryOnFailure();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            initializeDb(app);
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void initializeDb(IApplicationBuilder app)
        {


            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<TadbirDbContext>())
                {
                    context.Database.Migrate();
                }
            }

        }
    }
}
