namespace Hospital.BusinessLogic.Models;

public class Employee
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public Department Department { get; set; } = new Department();
    public List<WorkShift> WorkSchedule { get; set; } = new();
    public bool IsActive { get; set; }

    public bool Validate()
    {
        return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
    }

    public void AddShift(DayOfWeek day)
    {
        WorkSchedule.Add(new WorkShift { WeekDay = day });
    }
}