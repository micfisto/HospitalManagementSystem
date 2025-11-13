using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Departments;

namespace Hospital.DataAccess.Repository;

public class DepartmentTypeRepository : IDepartmentType
{
    private readonly HospitalContext _context;

    public DepartmentTypeRepository(HospitalContext context)
    {
        _context = context;
    }

    public async Task<DepartmentType?> GetIdAsync(Guid id)
    {
        return await _context.DepartmentTypes.FirstOrDefaultAsync(type => type.Id == id);
    }

    public async Task<List<DepartmentType>> GetAllAsync()
    {
        return await _context.DepartmentTypes.ToListAsync();
    }

    public async Task AddAsync(DepartmentType departmentType)
    {
        _context.DepartmentTypes.Add(departmentType);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DepartmentType departmentType)
    {
        _context.DepartmentTypes.Update(departmentType);
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