namespace Models.Employees;

public class Qualification
{
    public Guid Id { get; set; }= Guid.NewGuid();
    public required string Name { get; set; }

    public List<Nurse> Nurses { get; set; } = new();
}