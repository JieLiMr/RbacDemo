using ClassLibraryDto;
using Rbac.Entity;
using System;
using System.Collections.Generic;

namespace Rbac.IApplication
{
    public interface IAdminService : IBaseService<Admin, AddAdmin>
    {
        ResultDto Register(AddAdmin obj);

        bool Loign(AddAdmin obj);
    }
}
