using ClassLibraryDto;
using ClassLibraryDto.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.IApplication;
using Rbac.IRepository;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : BaseController<IAdminService, Admin, AddAdmin>
    {
        private readonly IAdminService service;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AdminController(IAdminService service, IHttpContextAccessor httpContextAccessor) : base(service)
        {
            this.service = service;
            this.httpContextAccessor = httpContextAccessor;
        }
        [HttpPost]
        public ResultDto Resign(AddAdmin addAdmin)
        {
            return service.Register(addAdmin);
        }
        [HttpPost]
        public LoignDto Loign(AddAdmin obj)
        {
           var result= service.Loign(obj);
        
            return result;
        }
        [HttpGet]
        public async Task<FileContentResult> CaptchaAsync()
        {
            var result = await service.GenerateCaptchaImageAsync();

            httpContextAccessor.HttpContext.Response.Cookies.Append("PwdCode",result.CaptchaCode);
         

            return File(result.CaptchaMemoryStream.ToArray(), "image/png");

        }
    }
}
