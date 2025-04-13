using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factory.EmployeeFactory
{
   public static class EmployeeFactory
    {
        public static GetEmployeeDto ToGetEmployeeDto(this Employee emp)
        {
            return new GetEmployeeDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                Email = emp.Email,
                IsActive = emp.IsActive,
                EmpGender = emp.EmployeeType.ToString(),
                EmpType = emp.Gender.ToString(),
                

            };
        }
        public static EmployeeDetailesDto ToGetEmployeeDetailesDto(this Employee emp)
        {
            return new EmployeeDetailesDto()
            {
                Id = emp.Id,
                Name = emp.Name,
                Age = emp.Age,
                Salary = emp.Salary,
                Email = emp.Email,
                IsActive = emp.IsActive,
                EmployeeType = emp.EmployeeType.ToString(),
                Gender = emp.Gender.ToString(),
                Address = emp.Address,
                CreatedBy = emp.CreatedBy,
                LastModifiedBy = emp.LastModifiedBy,
                PhoneNumber = emp.PhoneNumber,
                LastModifiedOn = emp.LastModifiedOn,
                CreatedOn = emp.CreatedOn,
                HiringDate = DateOnly.FromDateTime( emp.HireDate),
               

            };
        }
    }
}
