using Hospital.BusinessLogic.Interfaces;
using Models.Departments;
using Models.Patients;

namespace Hospital.BusinessLogic.PatientRules;

public class PatientRule : IPatientRule
{
    public Result<Patient> ValidateForCreate(Patient patient)
    {
        var rules = new List<IRule<Patient>>
        {
            new PatientNameRule(),
            new PatientSexRule(),
            new PatientDateOfBirthRule()
        };

        return ApplyRules(rules, patient);
    }

//придумать позже мониторинг возраста пациентов для перевода пациентов 18+ лет во взрослое отделение
    public List<DepartmentType> Hospitalization(Patient patient)
    {
        int age = CalculateAge(patient.DateOfBirth);

        if (age < 18)
            return new List<DepartmentType> { DepartmentType.Children };
        return new List<DepartmentType> { DepartmentType.Adult };
    }

    public Result<Patient> DischargedPatient(Patient patient)
    {
        var rule = new PatientDischargedRule();
        var result = rule.Check(patient);
        if (!result.Success)
            return result;
        patient.DischargeTime = DateTime.Now;
        return Result<Patient>.Ok(patient);
    }

    private int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        int age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age))
            --age;
        return age;
    }

    private Result<Patient> ApplyRules(IEnumerable<IRule<Patient>> rules, Patient patient)
    {
        foreach (var rule in rules)
        {
            var result = rule.Check(patient);
            if (!result.Success)
                return result;
        }

        return Result<Patient>.Ok(patient);
    }
}