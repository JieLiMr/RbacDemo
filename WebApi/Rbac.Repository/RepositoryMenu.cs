using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework;
namespace Rbac.Repository
{
    public class RepositoryMenu : BaseRepository<Menu, int>, IRepositoryMenu
    {
        public RepositoryMenu(MyDbContext myDbContext)
        {
            this.myDb= myDbContext;
        }




    }
}
