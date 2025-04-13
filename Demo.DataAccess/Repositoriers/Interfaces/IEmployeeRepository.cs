using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositoriers.Interfaces
{
    public interface IEmployeeRepository
    {
        int Add(Employee emp); 
        IEnumerable<Employee> GetAll(bool WithTracking = false);
        Employee? GetByID(int ID);
        int Remove(Employee emp);
        int Update(Employee emp);
    }
}
