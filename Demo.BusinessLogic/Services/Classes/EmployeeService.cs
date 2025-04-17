using AutoMapper;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.BusinessLogic.Factory.EmployeeFactory;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Repositoriers.Classes;
using Demo.DataAccess.Repositoriers.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IEmployeeRepository _employeeRepository,IMapper _imapper) : IEmployeeService
    {
      

        public IEnumerable<GetEmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            //var employeesToReturn = employees.Select(e => e.ToGetEmployeeDto());
            return _imapper.Map<IEnumerable<GetEmployeeDto>>(employees);
            //var res = _employeeRepository.GetIEnumerable()
            //.Select(emp => new GetEmployeeDto()
            //{
            //    Id = emp.Id,
            //    Name = emp.Name,
            //    Age = emp.Age,
            //}
            //).ToList();
            //return res;
            //  var res = _employeeRepository.GetIQueryable()
            //.Select(emp => new GetEmployeeDto()
            //{
            //    Id = emp.Id,
            //    Name = emp.Name,
            //    Age = emp.Age,
            //}
            //).ToList();
            //  return res;
        }

        public EmployeeDetailesDto? GetEmployeeById(int id)
        {
            var emp = _employeeRepository.GetByID(id);
      
            return emp is null?null : _imapper.Map<EmployeeDetailesDto>(emp);
            //return emp is null ? null : emp.ToGetEmployeeDetailesDto();

        }

        public int? UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var MappedEmp = _imapper.Map<Employee>(updateEmployeeDto);
            return _employeeRepository.Add(MappedEmp);
        }
        public int CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var MappedEmp = _imapper.Map<Employee>(createEmployeeDto);
            return _employeeRepository.Update(MappedEmp);
        }

        public bool DeletedEmployee(int Id)
        {
            var emp = _employeeRepository.GetByID(Id);
            if(emp is null)
            {
                return false;

            }
            else
            {
                emp.IsDeleted = true;
                var res = _employeeRepository.Update(emp);
                return res > 0 ? true : false;
            }
             
        }
    }
}
