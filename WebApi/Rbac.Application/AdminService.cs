using AutoMapper;
using ClassLibraryDto;
using Microsoft.AspNetCore.Http;
using Rbac.Entity;
using Rbac.IApplication;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rbac.Application
{
    public class AdminService : BaseService<Admin, AddAdmin>, IAdminService
    {
        private readonly IRepositoryAdmin db;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AdminService(IRepositoryAdmin db, IMapper mapper, IHttpContextAccessor httpContextAccessor,IConfigurationProvider configuration) : base(db, mapper)
        {

            this.db = db;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
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

        public bool Loign(AddAdmin obj)
        {
            var list= db.GetList(m => m.UserName == obj.UserName.ToLower());
            if(list != null)
            {
                return false;
            }
            else if(list.Count()>1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}
