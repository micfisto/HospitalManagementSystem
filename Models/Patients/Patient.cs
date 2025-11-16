using Models.Departments;
using Models.DoctorAppointments;

namespace Models.Patients;

public class Patient
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public bool IsDischarged = false;
    public DateTime? DischargeTime { get; set; }
    public required Sex Sex { get; set; }

    public MedicalRecord? MedicalRecord { get; set; }
    public Department? Department { get; set; }
    public required Guid DepartmentId { get; set; }

    public List<DoctorAppointment> DoctorAppointments { get; set; } = new();
    public List<Treatment> Treatments { get; set; } = new();
}