using Demo.DataAccess.Models;
using Demo.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demo.DataAccess.Repositoriers
{

    public class DepartmentReprository(AppDbContext dbContext) : IDepartmentReprository
    {
        private readonly AppDbContext _dbContext = dbContext;

        //CRUD Of Departmeny

        //public DepartmentReprository(AppDbContext dbContext)
        //{
        //   _dbContext = dbContext;
        //}

        public Department? GetByID(int ID) => _dbContext.Departments.Find(ID);

        public IEnumerable<Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return _dbContext.Departments.ToList();
            }
            else
            {
                return _dbContext.Departments.AsNoTracking().ToList();
            }
        }

        public int Add(Department dept)
        {
            _dbContext.Departments.Add(dept);
            return _dbContext.SaveChanges();
        }

        public int Update(Department dept)
        {
            _dbContext.Departments.Update(dept);
            return _dbContext.SaveChanges();
        }
        public int Remove(Department dept)
        {
            _dbContext.Departments.Remove(dept);
            return _dbContext.SaveChanges();

        }
    }
}
