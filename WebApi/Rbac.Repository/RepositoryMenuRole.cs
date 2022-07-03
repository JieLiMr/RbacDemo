using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class RepositoryMenuRole : BaseRepository<MenuRole, int>, IRepositoryMenuRole
    {
        public RepositoryMenuRole(MyDbContext myDbContext)
        {
            this.myDb = myDbContext;
        }
    }
}
