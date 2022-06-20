using ClassLibraryDto;
using Rbac.Entity;
using Rbac.IApplication;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Application
{
    public class MenuService : IMenuService
    {
        public MenuService(IRepositoryMenu db)
        {
            dbContext=db;
        }
        public IRepositoryMenu dbContext { get; set; }
        public List<MenuDto> GetAll()
        {
          var list=  dbContext.GetAll();
            MenuDto menus= new MenuDto();
            var menu=list.Where(m=>m.ParentId==0)
                .Select(m=>new MenuDto { 
                 MenuId=m.MenuId,
                  LinkUrl =m.LinkUrl,
                   MenuName=m.MenuName,
                   
                }).ToList();
            GetNodes(list,menu);
            return menu;
        }
        private void GetNodes(List<Menu> list, List<MenuDto> menu)
        {
            foreach (var m in menu)
            {
                var _list = list.Where(ms => ms.ParentId == m.MenuId).Select(ss => new MenuDto
                {
                    MenuId = ss.MenuId,
                    MenuName = ss.MenuName,
                    LinkUrl = ss.LinkUrl

                }).ToList();

                m.children.AddRange(_list);
                GetNodes(list, _list);
            }

               

                

                
        }
    }
}
