using Demo.DataAccess.Models;

namespace Demo.DataAccess.Repositoriers
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