using Rbac.IApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Rbac.IRepository;

namespace Rbac.Application
{
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class, new()
        where TDto : class, new()
    {
        private readonly IBaseRepository<TEntity, int> repository;
        private readonly IMapper mapper;
        public BaseService(IBaseRepository<TEntity, int> repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
       
        public int Create(TDto dto)
        {
            return repository.Create(mapper.Map<TEntity>(dto));
        }

        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public TDto Find(int id)
        {
            return mapper.Map<TDto>(repository.GetEntity(id));
        }

        public List<TDto> GetList()
        {
            return mapper.Map<List<TDto>>(repository.GetAll()) ;
        }

        public int Update(TDto dto)
        {
            return repository.Update(mapper.Map<TEntity>(dto));
        }
    }
}
