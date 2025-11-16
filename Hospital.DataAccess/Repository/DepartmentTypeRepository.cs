using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Departments;

namespace Hospital.DataAccess.Repository;

public class DepartmentTypeRepository : IRepository<DepartmentName>
{
    private readonly HospitalContext _context;

    public DepartmentTypeRepository(HospitalContext context)
    {
        _context = context;
    }

    public async Task<DepartmentName?> GetByIdAsync(Guid id)
    {
        return await _context.DepartmentTypes.FirstOrDefaultAsync(type => type.Id == id);
    }

    public async Task<List<DepartmentName>> GetAllAsync()
    {
        return await _context.DepartmentTypes.ToListAsync();
    }

    public async Task AddAsync(DepartmentName departmentName)
    {
        _context.DepartmentTypes.Add(departmentName);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DepartmentName departmentName)
    {
        _context.DepartmentTypes.Update(departmentName);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var departmentType = await _context.DepartmentTypes.FirstOrDefaultAsync(type => type.Id == id);
        if (departmentType != null)
        {
            _context.DepartmentTypes.Remove(departmentType);
            await _context.SaveChangesAsync();
        }
    }
}