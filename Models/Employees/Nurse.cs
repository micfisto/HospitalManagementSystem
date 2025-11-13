using Models.DoctorAppointments;

namespace Models.Employees;

public class Nurse : Employee
{
    public List<Qualification> Qualifications { get; set; } = new();
    public List<Treatment> Treatments { get; set; } = new();
}