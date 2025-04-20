using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Demo.BusinessLogic.DTOs.DepartmentDtos;
using Demo.BusinessLogic.Factory.DepartmentFactory;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Models;
using Demo.DataAccess.Repositoriers.Interfaces;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IUnitOfWork _unitOfWork, IMapper _imapper) : IDepartmentService
    {
        //private readonly IDepartmentReprository _departmentReprository = departmentReprository;

        /*So i Do Not Use DBContext*/
        //Get All Departments
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var Department = _unitOfWork.DepartmentReprository.GetAll();
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
            var Department = _unitOfWork.DepartmentReprository.GetByID(id);
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
          _unitOfWork.DepartmentReprository.Update(updateDepartmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }

        public bool DeletedDepartment(int Id)
        {
            var dept = _unitOfWork.DepartmentReprository.GetByID(Id);
            if (dept is null) return false;
            else
            {
              _unitOfWork.DepartmentReprository.Remove(dept);
                return _unitOfWork.SaveChanges()  > 0 ? true : false;
            }
        }
        int IDepartmentService.CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
           _unitOfWork.DepartmentReprository.Add(createDepartmentDto.ToEntity());
            return _unitOfWork.SaveChanges();
        }
    }
}
