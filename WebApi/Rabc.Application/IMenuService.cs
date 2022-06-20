using ClassLibraryDto;
using System;
using System.Collections.Generic;

namespace Rbac.IApplication
{
    public interface IMenuService
    {
        List<MenuDto> GetAll();
    }
}
