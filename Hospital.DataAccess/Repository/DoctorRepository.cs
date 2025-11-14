using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Employees;

namespace Hospital.DataAccess.Repository;

public class DoctorRepository : EmployeeRepository, IDoctorRepository
{
    private readonly HospitalContext _context;

    public DoctorRepository(HospitalContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Doctor>> GetDoctorSpecialization(string specialization)
    {
        return await _context.Employees.OfType<Doctor>()
            .Where(doctor => doctor.Specialization.Any(spec => spec.Name == specialization))
            .Include(doctor => doctor.Specialization)
            .ToListAsync();
    }
}