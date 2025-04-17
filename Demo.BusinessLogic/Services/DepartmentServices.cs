using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.BusinessLogic.DTOs;
using Demo.BusinessLogic.Factory;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositoriers;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentServices(IDepartmentReprository _departmentReprository) : IDepartmentServices
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

        public int? CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            var res = _departmentReprository.Add(createDepartmentDto.ToEntity());
            return res;
        }
        public int? UpdateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            var res = _departmentReprository.Update(createDepartmentDto.ToEntity());
            return res;
        }

    }
}
