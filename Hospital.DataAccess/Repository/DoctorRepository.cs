using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Employees;
using SQLitePCL;

namespace Hospital.DataAccess.Repository;

public class DoctorRepository : EmployeeRepository, IDoctorRepository
{
    public DoctorRepository(HospitalContext context) : base(context)
    {
    }

    public async Task<List<Doctor>> GetDoctorSpecialization(string specialization)
    {
        return await Context.Employees.OfType<Doctor>()
            .Where(doctor => doctor.Specialization.Any(spec => spec.Name == specialization))
            .Include(doctor => doctor.Specialization)
            .ToListAsync();
    }
}