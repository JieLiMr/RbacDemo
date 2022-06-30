using AutoMapper;
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
    public class RoleService : BaseService<Role,Role>, IRoleService

    {
        private readonly IRepositoryRole repository;
        private readonly IMapper mapper;

        public RoleService(IRepositoryRole repository, IMapper mapper) : base(repository, mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
    }
}
