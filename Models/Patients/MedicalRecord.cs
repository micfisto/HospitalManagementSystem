using Models.DoctorAppointments;

namespace Models.Patients;

public class MedicalRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public List<Diagnoses.Diagnosis> Diagnoses { get; set; } = new();
    public List<DoctorAppointment> DoctorAppointments { get; set; } = new();
    public List<Treatment> Treatments { get; set; } = new();

    public Epicrisis? Epicrisis { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}