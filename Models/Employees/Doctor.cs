using Models.DoctorAppointments;
using Models.Patients;

namespace Models.Employees;

public class Doctor : Employee
{
    public required List<Specialization> Specialization { get; set; } = new ();
    
    public List<Patient> AssignedPatient { get; set; } = new List<Patient>();
    public List<DoctorAppointment> DoctorAppointments { get; set; } = new();
}