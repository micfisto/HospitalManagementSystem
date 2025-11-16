using Models.Departments;

namespace Models.Employees;

public abstract class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }
}