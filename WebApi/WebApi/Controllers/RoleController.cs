using ClassLibraryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.IApplication;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController 
    {
        private readonly IRoleService service;
        private readonly IMenuRoleService menuRole;

        public RoleController(IRoleService service, IMenuRoleService menuRole)
        {
            this.service=service;
            this.menuRole = menuRole;
        }
        [HttpGet]

        public List<Role> getAll()
        {
          return service.GetList();
        }
        [HttpPost]
        public bool MenuRoleAdd(RoleMenuDto dto)
        {
           return menuRole.MenuRoleAdd(dto); 
        }
    }
}
