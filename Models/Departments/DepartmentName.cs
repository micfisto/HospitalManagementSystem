namespace Models.Departments;

public class DepartmentName
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public List<Department> Departments { get; set; } = new();
    public Guid DepartmentId { get; set; }
}