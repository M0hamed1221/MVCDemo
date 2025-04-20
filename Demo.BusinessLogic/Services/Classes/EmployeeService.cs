using AutoMapper;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.BusinessLogic.Factory.EmployeeFactory;
using Demo.BusinessLogic.Services.AttachmentService;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Repositoriers.Classes;
using Demo.DataAccess.Repositoriers.Interfaces;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IUnitOfWork _unitOfWork
                                ,IMapper _imapper
                                ,IAttachmentService _attachmentService ) : IEmployeeService
    {
        private readonly IAttachmentService attachmentService = _attachmentService;

        public IEnumerable<GetEmployeeDto> GetAllEmployees(string ? EmployeeSearchName)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrWhiteSpace(EmployeeSearchName))
            
                employees = _unitOfWork.EmployeeRepository.GetAll();
              
            
            else
            
                employees = (IEnumerable<Employee>)_unitOfWork.EmployeeRepository.GetAll(e => e.Name.ToLower().Contains(EmployeeSearchName.ToLower()));
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
            var emp = _unitOfWork.EmployeeRepository.GetByID(id);
      
            return emp is null?null : _imapper.Map<EmployeeDetailesDto>(emp);
            //return emp is null ? null : emp.ToGetEmployeeDetailesDto();

        }

        public int? UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var MappedEmp = _imapper.Map<Employee>(updateEmployeeDto);
            _unitOfWork.EmployeeRepository.Update(MappedEmp);
            return _unitOfWork.SaveChanges();
        }
        public int CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {


            var MappedEmp = _imapper.Map<Employee>(createEmployeeDto);
            var imageName = _attachmentService.Upload(createEmployeeDto.Image,"Images");
            MappedEmp.ImageName = imageName;
            _unitOfWork.EmployeeRepository.Add(MappedEmp);
            return _unitOfWork.SaveChanges();
        }

        public bool DeletedEmployee(int Id)
        {
            var emp = _unitOfWork.EmployeeRepository.GetByID(Id);
            if(emp is null)
            {
                return false;

            }
            else
            {
                emp.IsDeleted = true;
                _unitOfWork.EmployeeRepository.Update(emp);
                return _unitOfWork.SaveChanges()
                 > 0 ? true : false;
            }
             
        }

        public bool CreatePurchase()
        {

            //=>Purchase  insert 
            //=>inventory update qty
            //=> store update qty


            return true;
        }
    }
}
