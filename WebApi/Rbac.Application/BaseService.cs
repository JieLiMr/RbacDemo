using Rbac.IApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Rbac.IRepository;
using System.Linq.Expressions;

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
       
        public virtual int Create(TDto dto)
        {
            return repository.Create(mapper.Map<TEntity>(dto));
        }

        public virtual int Delete(int id)
        {
            return repository.Delete(id);
        }

        public virtual TDto Find(int id)
        {
            return mapper.Map<TDto>(repository.GetEntity(id));
        }

        public List<TDto> FindWhere(Expression<Func<TEntity, bool>> predicate)
        {
          return  mapper.Map <List<TDto>>(repository.GetList(predicate));
            
        }

        public virtual List<TDto> GetList()
        {
            return mapper.Map<List<TDto>>(repository.GetAll()) ;
        }

        public virtual int Update(TDto dto)
        {
            return repository.Update(mapper.Map<TEntity>(dto));
        }
    }
}
