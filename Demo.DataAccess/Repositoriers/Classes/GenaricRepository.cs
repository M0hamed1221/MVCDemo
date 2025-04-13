using Demo.DataAccess.Contexts;
using Demo.DataAccess.Models.SharedModel;
using Demo.DataAccess.Repositoriers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositoriers.Classes
{
    public class GenaricRepository<TEntity> (AppDbContext dbContext) : iGenaricRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _dbContext = dbContext;

        //CRUD Of Departmeny

        //public TEntityReprository(AppDbContext dbContext)
        //{
        //   _dbContext = dbContext;
        //}

        public TEntity? GetByID(int ID) => _dbContext.Set<TEntity>().Find(ID);

        public IEnumerable<TEntity> GetAll(bool WithTracking = false)
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

        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();

        }
    }
}
