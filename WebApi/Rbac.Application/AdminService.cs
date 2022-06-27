using AutoMapper;
using ClassLibraryDto;
using ClassLibraryDto.Admin;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Rbac.Entity;
using Rbac.IApplication;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Rbac.Application
{
    public class AdminService : BaseService<Admin, AddAdmin>, IAdminService
    {
        private readonly IRepositoryAdmin db;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration configuration;
        private readonly ICaptcha captcha;

        public AdminService(IRepositoryAdmin db, IMapper mapper, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, ICaptcha  captcha) : base(db, mapper)
        {

            this.db = db;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
            this.captcha = captcha;
        }

        public ResultDto Register(AddAdmin obj)
        {
            if (db.GetEntity(m => m.UserName == obj.UserName.ToLower()) != null)
            {
                return new ResultDto { Code = 1, Msg = "此用户以使用" };
            }
            obj.Password = Md5( obj.Password);
            obj.CreateTime = DateTime.Now;
            obj.LastLoginTime = DateTime.Now;
            obj.LastLoginIP = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            db.Create(mapper.Map<Admin>(obj));

            return new ResultDto { Code = 0, Msg = "注册成功" };
        }
        private string Md5(string val)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(val)).Select(x => x.ToString("x2")));
        }

        public LoignDto Loign(AddAdmin obj)
        {
            
            var list= db.GetList(m => m.UserName == obj.UserName.ToLower());
            LoignDto dto = new LoignDto();
            
            if (list.Count!=1)
            {
                dto.Code = 0;
                dto.Message = "用户密码不正确";
                return dto;
            }
            else
            {
                //生成Token令牌
                IList<Claim> claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Id, obj.UserName)
            };

                //JWT密钥
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"]));

                //算法，签名证书
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //过期时间
                DateTime expires = DateTime.UtcNow.AddHours(10);


                //Payload负载
                var token = new JwtSecurityToken(
                    issuer: configuration["JwtSettings:Issuer"], //发布者、颁发者
                    audience: configuration["JwtSettings:Audience"],  //令牌接收者
                    claims: claims, //自定义声明信息
                    notBefore: DateTime.UtcNow,  //创建时间
                    expires: expires,   //过期时间
                    signingCredentials: cred
                    );

                var handler = new JwtSecurityTokenHandler();

                //生成令牌
                string jwt = handler.WriteToken(token);
                dto.Code = 1;
                dto.Message = "登录成功";
                dto.JWTCode = jwt;
                return dto;
            }
        }

        public async Task<CaptchaResult> GenerateCaptchaImageAsync()
        {
            var code =  await captcha.GenerateRandomCaptchaAsync();

            var result = await captcha.GenerateCaptchaImageAsync(code);
            return result ;
            
        }
    }
}
