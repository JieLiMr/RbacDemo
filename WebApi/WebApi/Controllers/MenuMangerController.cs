using ClassLibraryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.IApplication;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MenuMangerController : ControllerBase
    {
        public MenuMangerController(IMenuService menu)
        {
            me = menu;
        }
        public IMenuService me { get; set; }
        [HttpGet]
        public List<MenuDto> getAll()
        {
            return me.GetAll();
        }
    }
}
