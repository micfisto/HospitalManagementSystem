using Hospital.BusinessLogic.Interfaces;
using Models.Patients;

namespace Hospital.BusinessLogic.PatientRules;

public class PatientDateOfBirthRule:IRule<Patient>
{
    public Result<Patient> Check(Patient? patient)
    {
        if (patient == null)
            return Result<Patient>.Fail($"Модель {nameof(Patient)} == null");
        
        if(patient.DateOfBirth==default)
            return Result<Patient>.Fail("Обязательно для заполнения");
        
        if(patient.DateOfBirth>DateTime.Today)
            return Result<Patient>.Fail("Некорректное значение");
        
        return Result<Patient>.Ok(patient);
    }
}