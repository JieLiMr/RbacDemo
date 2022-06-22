using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework;
namespace Rbac.Repository
{
    public class RepositoryMenu : IRepositoryMenu
    {
        public RepositoryMenu(MyDbContext myDbContext)
        {
            db = myDbContext;
        }

        public MyDbContext db  { get; }

        public bool Add(Menu obj)
        {
            db.Meau.Add(obj);
          return  db.SaveChanges() > 0;
        }

        public bool Delete(int id )
        {
            return db.Meau.DeleteByKey(id) > 0;    
        }

        public List<Menu> GetAll()
        {
          return  db.Meau.AsQueryable().ToList();
        }
        

        public bool Updete(Menu obj)
        {
            return db.Meau.Where(m => m.MenuId == obj.MenuId).UpdateFromQuery(m => new Menu { ParentId = obj.ParentId, MenuName = obj.MenuName, LinkUrl = obj.LinkUrl, }) > 0;
        }
    }
}
