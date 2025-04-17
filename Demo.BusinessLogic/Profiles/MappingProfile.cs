using AutoMapper;
using Demo.BusinessLogic.DTOs.EmployeeDtos;
using Demo.DataAccess.Models.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Profiles
{
   public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //CreateMap<TSource,TDestination>()
            /*Get*/
            CreateMap<Employee, GetEmployeeDto>()
                .ForMember( des=>des.EmpType,option=>option.MapFrom(emp=>emp.EmployeeType))
                .ForMember(dest=>dest.EmpGender,option=>option.MapFrom(emp=>emp.Gender))
                .ForMember(des=>des.Name,option=>option.MapFrom(emp=>emp.Department!= null ?emp.Department.Name:null))
                ;
            CreateMap<Employee, EmployeeDetailesDto>()
                .ForMember(dest=>dest.EmployeeType, option => option.MapFrom(emp => emp.EmployeeType))
                .ForMember(dest => dest.Gender, option => option.MapFrom(emp => emp.Gender))
                .ForMember(dest=>dest.HiringDate, option => option.MapFrom(emp=>DateOnly.FromDateTime( emp.HireDate)))
                .ForMember(des => des.Name, option => option.MapFrom(emp => emp.Department != null ? emp.Department.Name : null));


            CreateMap< CreateEmployeeDto, Employee>()
                .ForMember(dest=>dest.HireDate,option=>option.MapFrom(empdto=>empdto.HiringDate.ToDateTime(TimeOnly.MinValue)));
            CreateMap< UpdateEmployeeDto, Employee>()
                 .ForMember(dest => dest.HireDate, option => option.MapFrom(empdto => empdto.HiringDate.ToDateTime(TimeOnly.MinValue)));;





        }
    }
}
