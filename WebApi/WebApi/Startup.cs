using Microsoft.AspNetCore.Builder;
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
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rbac.Entity;
using Rbac.IRepository;
using Rbac.Repository;
using Rbac.IApplication;
using Rbac.Application;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Filters;

namespace WebApi
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

            services.AddControllers();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(
                o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JwtSettings:Issuer"],//������

                        //�Ƿ���֤������
                        ValidateAudience = true,
                        ValidAudience = Configuration["JwtSettings:Audience"],//������

                        //�Ƿ���֤��Կ
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:SecretKey"])),

                        ValidateLifetime = true, //��֤��������

                        RequireExpirationTime = true, //����ʱ��

                        ClockSkew = TimeSpan.Zero   //ƽ������ƫ��ʱ��
                    };
                }
                );

            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                //��header�����token�����ݵ���̨
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT��Ȩ(���ݽ�������ͷ�н��д���)ֱ���������������Bearer {token}(ע������֮����һ���ո�) \"",
                    Name = "Authorization",//jwtĬ�ϵĲ�������
                    In = ParameterLocation.Header,//jwtĬ�ϴ��Authorization��Ϣ��λ��(����ͷ��)
                    Type = SecuritySchemeType.ApiKey
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:8080")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()

                    );
            });

            services.AddDbContext<MyDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("sqlserver")));
            services.AddAutoMapper(Assembly.Load("Rbac.Application"));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IRepositoryMenu, RepositoryMenu>();
            services.AddScoped<IRepositoryAdmin, RepositoryAdmin>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICaptcha, RepositoryCaptcha>();
            services.AddScoped<IRepositoryRole,RepositoryRole>();
            services.AddScoped<IRoleService,RoleService>();      
            services.AddScoped<IRepositoryMenuRole,RepositoryMenuRole>();
            services.AddScoped<IMenuRoleService, MenuRoleService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            
            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseCookiePolicy();
          
            //app.UseCors(o => o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

            //��֤�м��
            app.UseAuthentication();

            //��Ȩ�м��
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
