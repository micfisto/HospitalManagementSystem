namespace Hospital.BusinessLogic.Models;

public class Patient
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public MedicalRecord MedicalRecord { get; set; }
}