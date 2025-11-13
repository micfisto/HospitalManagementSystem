using Models.Departments;

namespace Interfaces;

public interface IDepartmentType
{
    Task<DepartmentType?> GetIdAsync(Guid id);
    Task<List<DepartmentType>> GetAllAsync();
    Task AddAsync(DepartmentType departmentType);
    Task UpdateAsync(DepartmentType departmentType);
    Task DeleteAsync(Guid id);
}