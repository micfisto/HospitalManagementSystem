using Models.Departments;
using Models.DoctorAppointments;

namespace Models.Patients;

public class Patient
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public bool IsDischarged = false;
    public DateTime? DischargeTime { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required Sex Sex { get; set; }
    
    public MedicalRecord? MedicalRecord { get; set; }
    public Department? Department { get; set; }
    public required Guid DepartmentId { get; set; }

    public List<DoctorAppointment> DoctorAppointments { get; set; } = new();
    public List<Treatment> Treatments { get; set; } = new();

    
    public bool Validate()
    {
        if (string.IsNullOrWhiteSpace(FirstName))
            return false;
        if (string.IsNullOrWhiteSpace(LastName))
            return false;
        if (DateOfBirth > DateTime.Today)
            return false;
        if (!Enum.IsDefined(typeof(Sex), Sex))
            return false;
        
        return true;
    }
}