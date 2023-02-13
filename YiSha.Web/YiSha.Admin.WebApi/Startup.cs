using System.Text;
using System.IO;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Business.AutoJob;
using YiSha.Admin.WebApi.Controllers;
using AutoMapper;
using AspNetCoreWeChatCode2Session;

namespace YiSha.Admin.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            GlobalContext.LogWhenStart(env);
            GlobalContext.HostingEnvironment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "YiSha Api", Version = "v1" });
                options.IncludeXmlComments(xmlPath, true);
            });

            services.AddOptions();
            services.AddCors();
            services.AddControllers(options =>
            {
                options.ModelMetadataDetailsProviders.Add(new ModelBindingMetadataProvider());
            }).AddNewtonsoftJson(options =>
            {
                // 返回数据首字母不小写，CamelCasePropertyNamesContractResolver是小写
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            services.AddMemoryCache();

            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(GlobalContext.HostingEnvironment.ContentRootPath + Path.DirectorySeparatorChar + "DataProtection"));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //// 添加WeChat单例服务，资源库
            //services.AddSingleton<WeChat>(new WeChat("wxa1dcda4bdebfeb49", "fb66a8475d9e2dc0ec2d895fc6ea43cf"));
            // 去水印 wxf34df708a8253ee6 d02989fe68cb33c0deb0cf0a9feb3c1c
            // Max 软件库 wx372fd33b42934623 b3ecccc4eb6882f9e14b2d6943f22d79
            services.AddSingleton<WeChat>(new WeChat("wx372fd33b42934623", "b3ecccc4eb6882f9e14b2d6943f22d79"));
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);  // 注册Encoding

            GlobalContext.SystemConfig = Configuration.GetSection("SystemConfig").Get<SystemConfig>();
            GlobalContext.Services = services;
            GlobalContext.Configuration = Configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                GlobalContext.SystemConfig.Debug = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            string resource = Path.Combine(env.ContentRootPath, "Resource");
            FileHelper.CreateDirectory(resource);

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = GlobalContext.SetCacheControl
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = "/Resource",
                FileProvider = new PhysicalFileProvider(resource),
                OnPrepareResponse = GlobalContext.SetCacheControl
            });

            //var app = builder.Build();
            app.UseAuthorization();

            app.UseMiddleware(typeof(GlobalExceptionMiddleware));

            app.UseCors(builder =>
            {
                builder.WithOrigins(GlobalContext.SystemConfig.AllowCorsSite.Split(',')).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            });
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-doc/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-doc";
                c.SwaggerEndpoint("v1/swagger.json", "YiSha Api v1");
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=ApiHome}/{action=Index}/{id?}");
            });
            GlobalContext.ServiceProvider = app.ApplicationServices;
            if (!GlobalContext.SystemConfig.Debug)
            {
                new JobCenter().Start(); // 定时任务
            }
        }
    }
}