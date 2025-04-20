using Demo.DataAccess.Contexts;
using Demo.DataAccess.Models.SharedModel;
using Demo.DataAccess.Repositoriers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositoriers.Classes
{
    public class GenaricRepository<TEntity> (AppDbContext dbContext) : IGenaricRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext = dbContext;

        //CRUD Of Departmeny

        //public TEntityReprository(AppDbContext dbContext)
        //{
        //   _dbContext = dbContext;
        //}

        public TEntity? GetByID(int ID) => _dbContext.Set<TEntity>().Find(ID);

        public IEnumerable<TEntity> GetAll( bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Set<TEntity>().ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().AsNoTracking().ToList();
            }
        }

      
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector)
        {
            return _dbContext.Set<TEntity>()
                 .Select(selector).ToList();
        }

        public IEnumerable<TEntity> GetAll<TResult>(Expression<Func<TEntity, bool>> filter)
        {
            return _dbContext.Set<TEntity>()
                 .Where(filter)
                 .ToList();
        }
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
           
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
      
        }
        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
           

        }
      

     
    }
}
