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
        private readonly Lazy<IEmployeeRepository >_employeeRepository;
        private readonly Lazy<IDepartmentReprository> _departmentReprository;
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;

            this._employeeRepository = new Lazy<IEmployeeRepository>(()=> new EmployeeRepository(_appDbContext)) ;
            this._departmentReprository = new Lazy<IDepartmentReprository>(() => new DepartmentReprository(_appDbContext));
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public IDepartmentReprository DepartmentReprository => _departmentReprository.Value;

        public int SaveChanges()
        {
            return _appDbContext.SaveChanges();
        }
    }
}
