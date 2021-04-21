using CdSite.AOP;
using CdSite.Repository.Data;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CdSite
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(options => {
                options.AddPolicy(Constants.AdministratorRole, policy => policy.RequireClaim("dummy"));
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            //services.AddScoped<ITodoItemService, TodoItemService>();

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v0.0.1",
                    Title = "Todo Tool API",
                    Description = "框架说明文档",
                    TermsOfService = new Uri("https://cd-yang.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "cd-yang", 
                        Email = "yang-caidong@foxmail.com",
                        Url =new Uri("https://cd-yang.com")
                    }
                });

                var xmlPath = Path.Combine(AppContext.BaseDirectory, "CdSite.xml");
                c.IncludeXmlComments(xmlPath);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                #region Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                    //c.RoutePrefix = ""; // 首页显示 Swagger
                });
                #endregion
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index.html}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        // Autofac
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var basePath = ApplicationEnvironment.ApplicationBasePath;

            builder.RegisterType<BlogLogAOP>();
            //builder.RegisterType<PostService>().As<IPostService>();

            var serviceDllFile = Path.Combine(basePath, "Service.dll"); // 同 Service 工程名
            var assemblyServices = Assembly.LoadFrom(serviceDllFile);

            builder.RegisterAssemblyTypes(assemblyServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BlogLogAOP));
        }
    }
}
