using Rbac.Entity;
using Rbac.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Repository
{
    public class BaseRepository<TEntity, TKey> :IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        protected  MyDbContext myDb;
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual int BulkCreate(List<TEntity> entities)
        {
            myDb.Set<TEntity>().AddRange(entities);
            return myDb.SaveChanges();
        }
        /// <summary>
        /// 添加一条
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Create(TEntity entity)
        {
            myDb.Set<TEntity>().Add(entity);
            return myDb.SaveChanges();
        }
        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
           myDb.Set<TEntity>().Where(predicate).DeleteFromQuery();
           return myDb.SaveChanges();
        }
        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual int Delete(TKey key)
        {
           return myDb.Set<TEntity>().DeleteByKey(key);
        }

        /// <summary>
        /// 获取全部数据List
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> GetAll()
        {
           return myDb.Set<TEntity>().ToList();
        }

        /// <summary>
        /// 根据条件查出一个数据对象
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TEntity GetEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return myDb.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// 根据主键查出一条数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual TEntity GetEntity(TKey key)
        {
            return myDb.Set<TEntity>().Find(key);
        }
        /// <summary>
        /// 条件查询List
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
           return myDb.Set<TEntity>().Where(predicate).ToList();
        }
        /// <summary>
        /// 条件预查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>

        public virtual IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> predicate)
        {
            return myDb.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        /// 整个数据更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Update(TEntity entity)
        {
            myDb.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return myDb.SaveChanges();
        }
    }
}
