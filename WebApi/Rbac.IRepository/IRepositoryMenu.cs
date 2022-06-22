
using Rbac.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.IRepository
{
    public interface IRepositoryMenu
    {

        bool Add(Menu obj);
        bool Delete(int id);

        bool Updete(Menu obj );

        List<Menu> GetAll();
        

    }
}
