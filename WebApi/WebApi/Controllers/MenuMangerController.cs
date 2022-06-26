using ClassLibraryDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rbac.Entity;
using Rbac.IApplication;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
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

        [HttpGet]
        public List<AddMenuNameDto> GetAddDtoAll()
        {
            return me.GetAddDtoAll();
        }

        [HttpPost]
        public bool AddMenu(Menu obj)
        {
            obj.CreateTime = System.DateTime.Now;
            obj.IsDelete = false;
            return me.AddMenu(obj);
        }
        [HttpGet]
        public bool Del(int id)
        {
            return me.Del(id);
        }
        [HttpPost]
        public bool Edit(Menu obj)
        {
            return me.Edit(obj);
        }
    }
}
