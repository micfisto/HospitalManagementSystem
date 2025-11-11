namespace Hospital.BusinessLogic.Models;

public class Doctor : Employee
{
    public List<string> Specialization { get; set; } = new List<string>();
    public List<Patient> AssignedPatient { get; set; } = new List<Patient>();
    
}