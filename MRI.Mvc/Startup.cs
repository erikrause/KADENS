using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MRI.Mvc.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MriApi;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Logging;
using System.Net.Http;
using Microsoft.AspNetCore.HeaderPropagation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Authentication;

namespace MRI.Mvc
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
            //IdentityModelEventSource.ShowPII = true;    // DEBUG

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    Configuration.GetConnectionString("Postgres")));
            /*services.AddDefaultIdentity<IdentityUser<int>>(options => 
            { 
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();*/
            services.AddControllersWithViews();
            services.AddRazorPages();

            /*services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "402748804532-igldkrb545os0sfqm5la83e0fr4rq0no.apps.googleusercontent.com";
                options.ClientSecret = "KvEarGbj2LxurHKF5kol0GA1";
            });*/
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "https://localhost:6001";

                options.ClientId = "mvc";
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.Scope.Add("profile");
                options.GetClaimsFromUserInfoEndpoint = true;

                options.SaveTokens = true;

                options.Scope.Add("mri");
                //options.Scope.Add("offline_access");
            });

            services.AddHeaderPropagation(options =>
            {
                options.Headers.Add("Authorization");
                options.Headers.Add("Cookie", context =>
                {
                    //var accessToken = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "access-token")?.Value;
                    var accessToken = (context.HttpContext.GetTokenAsync("access_token")).Result;
                    return accessToken != null ? new StringValues($"token={accessToken}") : new StringValues();
                });
            });

            //services.AddSingleton(new MriApiClient(Configuration.GetSection("ApiUrl").GetSection("Mri").Value, new System.Net.Http.HttpClient()));
            services.AddHttpClient<IMriApiClient, MriApiClient>(c =>
            {
                c.BaseAddress = new Uri(Configuration.GetSection("ApiUrl").GetSection("Mri").Value);
                //c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", HttpContext.GetTokenAsync())
            }).AddHeaderPropagation(c =>
            {
                c.Headers.Add("Cookie");
            });
            //services.AddHttpClient()
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHeaderPropagation();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                         .RequireAuthorization();
                endpoints.MapRazorPages();
            });
        }
    }
    public class Prob : IHttpClientFactory
    {
        public HttpClient CreateClient(string name)
        {
            throw new NotImplementedException();
        }
    }/*
    public class AuthenticationDelegatingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await GetToken();
            request.Headers.Authorization = new AuthenticationHeaderValue(token.Scheme, token.AccessToken);
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                token = await RefreshToken();
                request.Headers.Authorization = new AuthenticationHeaderValue(token.Scheme, token.AccessToken);
                response = await base.SendAsync(request, cancellationToken);
            }

            return response;
        }
    }*/
}
