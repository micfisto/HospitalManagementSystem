using Models.Employees;
using Models.Patients;

namespace Models.Departments;

public class Department
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required DepartmentType Type { get; set; }
    
    public List<Employee> Employees { get; set; } = new();
    public required Guid EmployeeId { get; set; }
    public List<Patient> Patients { get; set; } = new();
    public required Guid PatientId { get; set; }

}