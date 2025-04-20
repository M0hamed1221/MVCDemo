using Demo.DataAccess.Models.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositoriers.Interfaces
{
    public interface IGenaricRepository<TEntity> where TEntity:BaseEntity
    {
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll(    bool WithTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity,TResult>> selector);
        IEnumerable<TEntity> GetAll<TResult>(Expression<Func<TEntity,bool>> filter);

        TEntity? GetByID(int ID);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        //IEnumerable<TEntity> GetIEnumerable();
        //IQueryable<TEntity> GetIQueryable();

    }
}
