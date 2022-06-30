using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.IApplication;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : BaseController<IRoleService,Role,Role>
    {
        private readonly IRoleService service;

        public RoleController(IRoleService service) : base(service)
        {
            this.service=service;
        }
    }
}
