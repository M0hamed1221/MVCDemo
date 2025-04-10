using Demo.BusinessLogic.DTOs;

namespace Demo.BusinessLogic.Services
{
    public interface IDepartmentServices
    {
        int CreateDepartment(CreateDepartmentDto createDepartmentDto);
        IEnumerable<DepartmentDto> GetAllDepartments();
        DepartmentDetailesDto? GetDepartmentById(int id);
        int? UpdateDepartment(UpdateDepartmentDto updateDepartmentDto);
    }
}