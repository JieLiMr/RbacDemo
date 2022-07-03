using AutoMapper;
using ClassLibraryDto;
using Rbac.Entity;
using Rbac.IApplication;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Application
{
    public class MenuRoleService : BaseService<MenuRole, MenuRole>, IMenuRoleService
    {
        private readonly IRepositoryMenuRole repository;
        private readonly IMapper mapper;

        public MenuRoleService(IRepositoryMenuRole repository,  IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public bool MenuRoleAdd(RoleMenuDto dto)
        {
            var find= repository.GetList(m=>m.RoleId==dto.id).ToList();
            if(find.Count>0)
            {
                return false;
            }
            var obj = dto.roleid.Select(m => new MenuRole { MenuId = m, RoleId = dto.id }).ToList();
            return repository.BulkCreate(obj) > 0;

        }
    }
}
