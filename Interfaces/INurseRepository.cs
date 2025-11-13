using Models.Employees;

namespace Interfaces;

public interface INurseRepository:IEmployeeRepository
{
    Task<List<Nurse>> GetNurseQualification(string qualification);
}