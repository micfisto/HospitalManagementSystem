namespace Models.Employees;

public class Specialization
{
    public Guid Id { get; set; }= Guid.NewGuid();
    public required string Name { get; set; }

    public List<Doctor> Doctors { get; set; } = new();
}