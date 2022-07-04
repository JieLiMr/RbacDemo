using ClassLibraryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.IApplication;
using System.Collections.Generic;
using System.Linq;

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
        public bool MenuRoleAdd(RoleMenuAddDto dto)
        {
           return menuRole.MenuRoleAdd(dto); 
        }
        [HttpGet]
        public List<int> GetMenuRoles(int roleid)
        {
            return menuRole.FindWhere(m => m.RoleId == roleid).Select(m => m.MenuId).ToList();  
        }
    }
}
