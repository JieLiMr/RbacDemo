using AutoMapper;
using ClassLibraryDto;
using Microsoft.AspNetCore.Http;
using Rbac.Entity;
using Rbac.IApplication;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbac.Application
{
    public class MenuService :BaseService<Menu,Menu>, IMenuService
    {
        private readonly IRepositoryMenu db;
        private readonly IHttpContextAccessor httpContextAccessor;
        public MenuService(IRepositoryMenu db,IMapper mapper, IHttpContextAccessor  httpContextAccessor) :base(db,mapper)
        {
           
            this.db = db;
            this.httpContextAccessor = httpContextAccessor;
        }
        public List<MenuDto> GetAll()
        {
          var list= db.GetAll();
            MenuDto menus= new MenuDto();
            var menu=list.Where(m=>m.ParentId==0)
                .Select(m=>new MenuDto { 
                 MenuId=m.MenuId,
                  LinkUrl =m.LinkUrl,
                   MenuName=m.MenuName,
                   
                }).ToList();
             httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
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


        public List<AddMenuNameDto> GetAddDtoAll()
        {
            var list = db.GetAll();
            AddMenuNameDto menus = new AddMenuNameDto();
            var menu = list.Where(m => m.ParentId == 0)
                .Select(m => new AddMenuNameDto
                {
                    value = m.MenuId,
                    label = m.MenuName,

                }).ToList();
            GetAddMenuDtoNodes(list, menu);
            return menu;
        }
        private void GetAddMenuDtoNodes(List<Menu> list, List<AddMenuNameDto> menu)
        {
            foreach (var m in menu)
            {
                var _list = list.Where(ms => ms.ParentId == m.value).Select(ss => new AddMenuNameDto
                {
                    value = ss.MenuId,
                    label = ss.MenuName,

                }).ToList();

                m.children.AddRange(_list);
                GetAddMenuDtoNodes(list, _list);
            }






        } 
        public bool Del(int id)
        {
            bool isOk = false;
            var list=db.GetAll();
            if( list.Where(m=>m.ParentId==id).Count()>0)
            {
                isOk = false;
            }
            else
            {
               isOk=db.Delete(id)>0;
            }
            return isOk;
        }

        public bool Edit(Menu dto)
        {
           
            return db.Update(dto)>0;
        }

        public bool AddMenu(Menu obj)
        {
            throw new NotImplementedException();
        }
    }
}
