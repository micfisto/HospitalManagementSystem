using Models.Employees;

namespace Interfaces;

public interface IEmployeeRepository<T> : IRepository<Employee> where T : class
{
    
}