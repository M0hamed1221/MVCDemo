using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Interfaces
{
   public interface IEmployeeService
    {
        int CreateEmployee(CreateEmployeeDto createEmployeeDto);
        IEnumerable<GetEmployeeDto> GetAllEmployees();
        EmployeeDetailesDto? GetEmployeeById(int id);
        int? UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);

        bool DeletedEmployee(int Id);
    }
}
