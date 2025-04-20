using Demo.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Repositoriers.Interfaces;


namespace Demo.DataAccess.Repositoriers.Classes
{

    public class DepartmentReprository(AppDbContext dbContext) :
        GenaricRepository<Department>(dbContext)
        , IDepartmentReprository
    {
        //private readonly AppDbContext _dbContext = dbContext;

        ////CRUD Of Departmeny

        ////public DepartmentReprository(AppDbContext dbContext)
        ////{
        ////   _dbContext = dbContext;
        ////}

        //public Department? GetByID(int ID) => _dbContext.Departments.Find(ID);

        //public IEnumerable<Department> GetAll(bool WithTracking = false)
        //{
        //    if (WithTracking)
        //    {
        //        return _dbContext.Departments.ToList();
        //    }
        //    else
        //    {
        //        return _dbContext.Departments.AsNoTracking().ToList();
        //    }
        //}

        //public int Add(Department dept)
        //{
        //    _dbContext.Departments.Add(dept);
        //    return _dbContext.SaveChanges();
        //}

        //public int Update(Department dept)
        //{
        //    _dbContext.Departments.Update(dept);
        //    return _dbContext.SaveChanges();
        //}
        //public int Remove(Department dept)
        //{
        //    _dbContext.Departments.Remove(dept);
        //    return _dbContext.SaveChanges();

        //}
        int IDepartmentReprository.Add(Department dept)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Department> IDepartmentReprository.GetAll(bool WithTracking)
        {
            throw new NotImplementedException();
        }

        Department? IDepartmentReprository.GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        int IDepartmentReprository.Remove(Department dept)
        {
            throw new NotImplementedException();
        }

        int IDepartmentReprository.Update(Department dept)
        {
            throw new NotImplementedException();
        }
    }
}
