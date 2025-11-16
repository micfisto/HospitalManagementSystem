using Models.Employees;

namespace Interfaces;

public interface IDoctorRepository:IEmployeeRepository<Doctor>
{
    Task<List<Doctor>> GetDoctorSpecialization(string specialization);
}