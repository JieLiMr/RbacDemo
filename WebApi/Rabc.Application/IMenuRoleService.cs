using ClassLibraryDto;
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IApplication
{
    public interface IMenuRoleService:IBaseService<MenuRole, MenuRole>
    {
        bool MenuRoleAdd(RoleMenuDto dto);
    }
}
