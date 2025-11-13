using Models.Employees;

namespace Interfaces;

public interface IDoctorRepository:IEmployeeRepository
{
    Task<List<Doctor>> GetDoctorSpecialization(string specialization);
}