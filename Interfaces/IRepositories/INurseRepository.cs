using Models.Employees;

namespace Interfaces;

public interface INurseRepository: IEmployeeRepository<Nurse>
{
    Task<List<Nurse>> GetNurseQualification(string qualification);
}