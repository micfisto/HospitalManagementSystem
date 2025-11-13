namespace Models.Departments;

public class DepartmentType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }
}