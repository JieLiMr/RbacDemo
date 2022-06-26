using ClassLibraryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.IApplication;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : BaseController<IAdminService, Admin, AddAdmin>
    {
        private readonly IAdminService service;

        public AdminController(IAdminService service) : base(service)
        {
            this.service = service;
        }
        [HttpPost]
        public ResultDto  Resign(AddAdmin addAdmin)
        {
            return service.Register(addAdmin);
        }
    }
}
