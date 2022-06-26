using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class RepositoryAdmin : BaseRepository<Admin, int>, IRepositoryAdmin
    {
        public RepositoryAdmin(MyDbContext myDbContext)
        {
            this.myDb = myDbContext;
        }
    }
}
