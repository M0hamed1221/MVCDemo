using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Models.EmployeeModels;

namespace Demo.DataAccess.Repositoriers.Interfaces
{
    public interface IDepartmentReprository : IGenaricRepository<Department>
    {
        int Add(Department dept);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetByID(int ID);
        int Remove(Department dept);
        int Update(Department dept);
       
    }
}