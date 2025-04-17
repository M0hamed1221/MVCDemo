using Demo.BusinessLogic.DTOs;
using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factory
{
    public static class DepartmentFactory
    {

        //Mapping Extentsion Method

        public static DepartmentDto ToDepartmentDto(this Department department)
        {
            return new DepartmentDto()
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.CreatedOn,

            };
        }
        public static DepartmentDetailesDto ToDepartmentDetailesDto(this Department department)
        {
            return new DepartmentDetailesDto()
            {
                DeptId = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.CreatedOn,
                LastModifiedBy = department.LastModifiedBy,
                IsDeleted = department.IsDeleted,
            };
        }
        public static Department ToEntity(this CreateDepartmentDto dto)
        {
            return new Department()
            {
                Name = dto.Name,
                Code = dto.Code,
                Description = dto.Description,
                CreatedOn = dto.DateOfCreation,
            };

        }
    }
}
