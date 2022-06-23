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

      

        //public bool Add(Menu obj)
        //{
        //    db.Meau.Add(obj);
        //    return db.SaveChanges() > 0;
        //}

        //public bool Delete(int id)
        //{
        //    return db.Meau.DeleteByKey(id) > 0;
        //}

        //public List<Menu> GetAll()
        //{
        //    return db.Meau.AsQueryable().ToList();
        //}


        //public bool Updete(Menu obj)
        //{
        //    return db.Meau.Where(m => m.MenuId == obj.MenuId).UpdateFromQuery(m => new Menu { ParentId = obj.ParentId, MenuName = obj.MenuName, LinkUrl = obj.LinkUrl, }) > 0;
        //}

    }
}
