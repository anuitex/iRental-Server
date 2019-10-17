using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using iRental.BusinessLogicLayer.DependencyInjection;
using iRental.BusinessLogicLayer.Identity;
using iRental.BusinessLogicLayer.Options;
using iRental.Common.Options;
using iRental.Domain.Entities.User;
using iRental.Domain.Identity;
using iRental.Firestore.Identity.DependencyInjection;
using iRental.Presentation.Extensions;
using iRental.Repository.Firestore.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace iRental.Presentation
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
            services.SetOptions(Configuration);
            var serviceProvider = services.BuildServiceProvider();

            var firestoreOptions = serviceProvider.GetRequiredService<IOptions<FirestoreOptions>>();

            services.AddFirestore(firestoreOptions);
            services.AddFileStore();

            services.AddRepositories();
            services.AddManagers();

            services.AddApplicationIdentity();
            services.AddIdentity<UserEntity, RoleIdentity>(options =>
            {
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
            })
                .AddUserManager<ApplicationUserManager>()
                .AddDefaultTokenProviders();


            var jwtAuthOptions = serviceProvider.GetRequiredService<IOptions<JwtAuthOption>>().Value;
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = jwtAuthOptions.GetTokenValidationParameters();
            });

            services.AddServices();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Add OpenAPI/Swagger document
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0.0.1", new Info { Title = "iRental Api", Version = "v0.0.1" });
                c.DescribeAllEnumsAsStrings();
                c.MapType<Guid>(() => new Schema { Type = "string", Format = "uuid", Example = Guid.Empty });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //todo: add logger
            //ExceptionHandlerSetup.Setup();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();

            // Add OpenAPI/Swagger middlewares
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0.0.1/swagger.json", "Loyalty");
            });
        }
    }
}
