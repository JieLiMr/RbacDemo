using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class RepositoryRole : BaseRepository<Role, int>, IRepositoryRole
    {
        public RepositoryRole(MyDbContext myDbContext)
        {
            this.myDb= myDbContext;
        }
    }
}
