using Models.Departments;

namespace Models.Patients;

public class Epicrisis
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required DateTime Date { get; set; }
    public required string Summary { get; set; }
    public required string Recommendations { get; set; }
    public required string AttendingDoctor { get; set; }
    public required MedicalRecord MedicalRecord { get; set; }
    public Guid MedicalRecordId { get; set; }
}