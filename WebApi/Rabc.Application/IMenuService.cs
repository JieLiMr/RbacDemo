using ClassLibraryDto;
using Rbac.Entity;
using System;
using System.Collections.Generic;

namespace Rbac.IApplication
{
    public interface IMenuService
    {
        List<MenuDto> GetAll();
        List<AddMenuDto> GetAddDtoAll();
        bool AddMenu(Menu  obj);
        public bool Del(int id);
    }
}
