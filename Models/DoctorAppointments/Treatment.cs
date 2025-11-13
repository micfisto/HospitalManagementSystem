using Models.Employees;
using Models.Patients;

namespace Models.DoctorAppointments;

public class Treatment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public required Guid NurseId { get; set; }
    
    public MedicalRecord MedicalRecord { get; set; }
    public required Guid MedicalRecordId { get; set; } 
    public Nurse Nurse { get; set; }
    public required DateTime Date { get; set; }
}