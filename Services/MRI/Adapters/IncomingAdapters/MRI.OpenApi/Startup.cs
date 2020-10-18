using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MRI.OpenApi.Filters;
using MRI.OutgoingPorts;
using MRI.PostgresRepository;
using Swashbuckle.AspNetCore.Filters;

namespace MRI.OpenApi
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
            // Getting connection string.
            /*var configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = configurationBuilder.Build();*/
            string connectionString = Configuration.GetConnectionString("Postgres");
            //

            services.AddDbContext<MriDbContext>(opt => opt.UseNpgsql(connectionString));
            services.AddScoped<IRepository, EFCoreRepository>();
            services.AddControllers();

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication("Bearer", options =>
                {
                    options.ApiName = "mri";
                    options.Authority = "https://localhost:6001";
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MRI API",
                    Description = "API МРТ сервиса для проекта КАДНЕС",
                    Contact = new OpenApiContact
                    {
                        Name = "Erkin Kamilov",
                        Email = "erkimkamilov@gmail.com"
                    }
                });

                //c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{e.HttpMethod}");
                /*
                c.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    //OpenIdConnectUrl = new Uri("https://localhost:6001")
                });*/
                /*
                c.AddSecurityDefinition("Oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri("https://localhost:6001/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:6001/connect/token"),
                            Scopes = new Dictionary<string, string>()
                            {
                                { "mri", "Mri API" }
                            }
                        }
                    }
                });*/
                /*
                c.AddSecurityDefinition("OpenID", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.OpenIdConnect,
                    OpenIdConnectUrl = new Uri("https://localhost:6001")
                });*/

                c.AddSecurityDefinition("Oauth2", new OpenApiSecurityScheme()
                {
                    /*BearerFormat = "JWT",
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Name = "Authorization",*/
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:6001/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:6001/connect/token"),
                            Scopes = new Dictionary<string, string>()
                            {
                                { "mri", "MRI API" }
                            }
                        }
                    }
                });

                c.OperationFilter<AuthorizeCheckOperationFilter>();

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
            });
            //services.AddSwaggerDocument();

            /*services.AddAuthorization(options =>
            {
                options.AddPolicy("MriScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "mri");
                });
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MRI API");

                c.OAuthClientId("swaggerUI");
                c.OAuthAppName("Demo API - Swagger");
                c.OAuthClientSecret("secret");
                c.OAuthUsePkce();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                    //.RequireAuthorization();
            });

            // Swagger:
            //app.UseOpenApi(); // serve OpenAPI/Swagger documents
            //app.UseSwaggerUi3(); // serve Swagger UI
            //app.UseReDoc(); // serve ReDoc UI -- TODO: что делает?

        }
    }
}
