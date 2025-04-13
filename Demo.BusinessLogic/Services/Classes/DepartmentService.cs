using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.Factory.DepartmentFactory;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositoriers.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IDepartmentReprository _departmentReprository) : IDepartmentService
    {
        //private readonly IDepartmentReprository _departmentReprository = departmentReprository;

        /*So i Do Not Use DBContext*/
        //Get All Departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var Department = _departmentReprository.GetAll();
            var departmentsToReturn = Department.Select(d => d.ToDepartmentDto());
            //var departmentsToReturn= Department.Select(d => new DepartmentDto()
            //{
            //       DeptId = d.Id,
            //       Name = d.Name,   
            //       Code = d.Code,
            //       Description = d.Description,
            //       DateOfCreation=d.CreatedOn,
            //}
            //);
            return departmentsToReturn;
        }

        public DepartmentDetailesDto? GetDepartmentById(int id)
        {
            var Department = _departmentReprository.GetByID(id);
            return Department is null ? null : Department.ToDepartmentDetailesDto();
            //{
            //    DeptId = Department.Id,
            //    Name = Department.Name,
            //    Code = Department.Code,
            //    Description = Department.Description,
            //    DateOfCreation = Department.CreatedOn,
            //    LastModifiedBy = Department.LastModifiedBy,
            //    IsDeleted = Department.IsDeleted,
            //};


        }

      
        public int? UpdateDepartment(UpdateDepartmentDto  updateDepartmentDto)
        {
            var res = _departmentReprository.Update(updateDepartmentDto.ToEntity());
            return res;
        }

        public bool DeletedDepartment(int Id)
        {
            var dept = _departmentReprository.GetByID(Id);
            if (dept is null) return false;
            else
            {
                var res = _departmentReprository.Remove(dept);
                return res > 0 ? true : false;
            }
        }
        int IDepartmentService.CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            var res = _departmentReprository.Add(createDepartmentDto.ToEntity());
            return res;
        }
    }
}
