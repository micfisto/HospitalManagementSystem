using Models.Patients;

namespace Models.Diagnoses;

public class Symptom
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }

    public List<Diagnoses.Diagnosis> Diagnoses { get; set; } = new();
    public List<MedicalRecord> MedicalRecords { get; set; } = new();
}