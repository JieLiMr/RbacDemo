using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.IApplication
{
    public interface IBaseService<TEntity,TDto>
        where TEntity : class,new()
        where TDto:class,new()
	{
        int Create(TDto dto);
        int Update(TDto dto);
        int Delete(int id);
        TDto Find(int id);
        List<TDto> GetList();
        List<TDto> FindWhere(Expression<Func<TEntity, bool>> predicate);
    }

}
