using Models.Patients;

namespace Models.Diagnoses;

public class Diagnosis
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Code { get; set; }
    public required string Name { get; set; }

    public List<Symptom> Symptoms { get; set; } = new();
    public List<MedicalRecord> MedicalRecords { get; set; } = new();
}