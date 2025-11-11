namespace Hospital.BusinessLogic.Models;

public class MedicalRecord
{
    public Guid Id { get; set; }
    public string Diagnosis { get; set; }
    public List<string> DoctorAppointments { get; set; } = new();
    public Epicrisis? Epicrisis { get; set; }
    public List<Treatment> Treatments { get; set; } = new();
}