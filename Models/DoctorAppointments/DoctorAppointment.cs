using Models.Employees;
using Models.Patients;

namespace Models.DoctorAppointments;

public class DoctorAppointment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required DateTime DateAppointment { get; set; }
    public required Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public required Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    public required Guid MedicalRecordId { get; set; }
    public MedicalRecord MedicalRecord { get; set; }
    public required string VisitNotes { get; set; }
}