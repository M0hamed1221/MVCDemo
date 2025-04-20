using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Repositoriers.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositoriers.Interfaces
{
    public interface IEmployeeRepository: IGenaricRepository<Employee>
    {
        int Add(Employee emp); 
        IEnumerable<Employee> GetAll(string EmployeeSearchName,bool WithTracking = false);
        Employee? GetByID(int ID);
        int Remove(Employee emp);
        int Update(Employee emp);
    }
}
