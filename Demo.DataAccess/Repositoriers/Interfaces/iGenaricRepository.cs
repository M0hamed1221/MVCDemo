﻿using Demo.DataAccess.Models.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositoriers.Interfaces
{
    public interface iGenaricRepository<TEntity> where TEntity:BaseEntity
    {
        int Add(TEntity entity);
        IEnumerable<TEntity> GetAll(bool WithTracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<TEntity,TResult>> selector);

        TEntity? GetByID(int ID);
        int Remove(TEntity entity);
        int Update(TEntity entity);
        //IEnumerable<TEntity> GetIEnumerable();
        //IQueryable<TEntity> GetIQueryable();

    }
}
