using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Employees;

namespace Hospital.DataAccess.Repository;

public class EmployeeRepository : IRepository<Employee>
{
    protected readonly HospitalContext Context;

    public EmployeeRepository(HospitalContext context)
    {
        Context = context;
    }

    public async Task<Employee?> GetByIdAsync(Guid id)
    {
        return await Context.Employees.Include(employee => employee.Department)
            .FirstOrDefaultAsync(employee => employee.Id == id);
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        return await Context.Employees.Include(employees => employees.Department).ToListAsync();
    }

    public async Task AddAsync(Employee employee)
    {
        Context.Employees.Add(employee);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        Context.Employees.Update(employee);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var employee = await Context.Employees.FirstOrDefaultAsync(employee => employee.Id == id);
        if (employee != null)
        {
            Context.Employees.Remove(employee);
            await Context.SaveChangesAsync();
        }
    }
}