using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Employees;

namespace Hospital.DataAccess.Repository;

public class NurseRepository : EmployeeRepository, INurseRepository
{
    public NurseRepository(HospitalContext context) : base(context)
    {
    }

    public async Task<List<Nurse>> GetNurseQualification(string qualification)
    {
        return await Context.Employees.OfType<Nurse>().Where(nurse => nurse.Qualification.Name == qualification)
            .Include(nurse => nurse.Qualification)
            .ToListAsync();
    }
}