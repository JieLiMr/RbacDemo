using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var obj=db.Meau.Find(id);
           db.Meau.Remove(obj);
            return db.SaveChanges() > 0;
        }

        public List<Menu> GetAll()
        {
          return  db.Meau.AsQueryable().ToList();
        }
        

        public bool Updete(Menu obj)
        {
            db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
    }
}
