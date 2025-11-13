using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Departments;

namespace Hospital.DataAccess.Repository;

public class DepartmentRepository:IDepartmentRepository
{
    private HospitalContext _context;

    public DepartmentRepository(HospitalContext context)
    {
        _context = context;
    }
    
    public async Task<Department?> GetIdAsync(Guid id)
    {
        return await _context.Departments.Include(department => department.Employees).FirstOrDefaultAsync(department => department.Id==id);
    }

    public async Task<List<Department>> GetAllAsync()
    {
        return await _context.Departments.Include(department => department.Employees).ToListAsync();
    }

    public async Task AddAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(department => department.Id == id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}