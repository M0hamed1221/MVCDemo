using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositoriers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositoriers.Classes
{
    public class UnitOfWork : IUnitOfWork
        
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentReprository _departmentReprository;
        private readonly AppDbContext _appDbContext;

        public UnitOfWork
            (IEmployeeRepository employeeRepository,
            IDepartmentReprository departmentReprository,
            AppDbContext appDbContext)
        {
            this._employeeRepository = employeeRepository;
            this._departmentReprository = departmentReprository;
            this._appDbContext = appDbContext;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository    ;

        public IDepartmentReprository DepartmentReprository => _departmentReprository;

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
