using Demo.DataAccess.Models.DepartmentModels;

namespace Demo.DataAccess.Repositoriers.Interfaces
{
    public interface IDepartmentReprository
    {
        int Add(Department dept);
        IEnumerable<Department> GetAll(bool WithTracking = false);
        Department? GetByID(int ID);
        int Remove(Department dept);
        int Update(Department dept);
       
    }
}