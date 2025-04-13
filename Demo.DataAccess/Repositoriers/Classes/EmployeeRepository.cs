using Demo.DataAccess.Contexts;
using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Repositoriers.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositoriers.Classes
{
   public class EmployeeRepository(AppDbContext dbContext)
        : GenaricRepository<Employee>(dbContext),
        IEmployeeRepository
    {
      
        //private readonly AppDbContext _dbContext = dbContext;

        ////CRUD Of Departmeny

        ////public EmployeeReprository(AppDbContext dbContext)
        ////{
        ////   _dbContext = dbContext;
        ////}

        //public Employee? GetByID(int ID) => _dbContext.Employees.Find(ID);

        //public IEnumerable<Employee> GetAll(bool WithTracking = false)
        //{
        //    if (WithTracking)
        //    {
        //        return _dbContext.Employees.ToList();
        //    }
        //    else
        //    {
        //        return _dbContext.Employees.AsNoTracking().ToList();
        //    }
        //}

        //public int Add(Employee emp)
        //{
        //    _dbContext.Employees.Add(emp);
        //    return _dbContext.SaveChanges();
        //}

        //public int Update(Employee emp)
        //{
        //    _dbContext.Employees.Update(emp);
        //    return _dbContext.SaveChanges();
        //}
        //public int Remove(Employee emp)
        //{
        //    _dbContext.Employees.Remove(emp);
        //    return _dbContext.SaveChanges();

        //}
    }
}