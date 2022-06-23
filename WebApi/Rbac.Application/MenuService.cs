using AutoMapper;
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
        private readonly IMapper mapper;

        public MenuService(IRepositoryMenu db,IMapper mapper)
        {
            dbContext=db;
            this.mapper = mapper;
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


        public List<AddMenuDto> GetAddDtoAll()
        {
            var list = dbContext.GetAll();
            AddMenuDto menus = new AddMenuDto();
            var menu = list.Where(m => m.ParentId == 0)
                .Select(m => new AddMenuDto
                {
                    value = m.MenuId,
                    label = m.MenuName,

                }).ToList();
            GetAddMenuDtoNodes(list, menu);
            return menu;
        }
        private void GetAddMenuDtoNodes(List<Menu> list, List<AddMenuDto> menu)
        {
            foreach (var m in menu)
            {
                var _list = list.Where(ms => ms.ParentId == m.value).Select(ss => new AddMenuDto
                {
                    value = ss.MenuId,
                    label = ss.MenuName,

                }).ToList();

                m.children.AddRange(_list);
                GetAddMenuDtoNodes(list, _list);
            }






        }

        public bool AddMenu(Menu obj)
        {
            var s=mapper.Map<EditMenuDto>(obj);
            return dbContext.Add(obj);
        }

        public bool Del(int id)
        {
            bool isOk = false;
            var list=dbContext.GetAll();
            if( list.Where(m=>m.ParentId==id).Count()>0)
            {
                isOk = false;
            }
            else
            {
               isOk=dbContext.Delete(id);
            }
            return isOk;
        }

        public bool Edit(Menu dto)
        {
           
            return dbContext.Updete(dto);
        }
    }
}
