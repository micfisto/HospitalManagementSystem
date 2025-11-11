namespace Hospital.BusinessLogic.Models;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DepartmentType Type { get; set; }
    public List<Employee> Employees { get; set; } = new ();
    public List<Patient> Patients { get; set; } = new ();
}