using Models.Departments;

namespace Interfaces;

public interface IDepartmentRepository
{
    Task<Department?> GetIdAsync(Guid id);
    Task<List<Department>> GetAllAsync();
    Task AddAsync(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(Guid id);
}