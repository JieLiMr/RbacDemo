using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.IApplication;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TService, TEnity, TDto> : ControllerBase
         where TService : IBaseService<TEnity, TDto>
        where TEnity : class, new()
        where TDto : class, new()
    {
        private readonly TService service;

        public BaseController(TService  service)
        {
            this.service = service;
        }


         [HttpPost]
        public IActionResult Create(TDto dto)
        {
            return Ok(service.Create(dto));
        }

        [HttpPost]
        public IActionResult Update(TDto dto)
        {
            return Ok(service.Update(dto));
        }

        [HttpGet]
        public IActionResult Find(int id)
        {
            return Ok(service.Find(id));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return Ok(service.Delete(id));
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return new JsonResult(service.GetList());
        }
    }
}
