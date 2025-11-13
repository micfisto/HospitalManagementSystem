using Models.Departments;

namespace Models.Employees;

public abstract class Employee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    public bool IsActive { get; set; }

    public bool Validate()
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            return false;
        if (string.IsNullOrWhiteSpace(LastName))
            return false;
        
        return true;
    }
}