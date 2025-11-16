using Hospital.BusinessLogic.Interfaces;
using Models.Patients;

namespace Hospital.BusinessLogic.PatientRules;

public class PatientNameRule : IRule<Patient>
{
    public Result<Patient> Check(Patient? patient)
    {
        if (patient == null)
            return Result<Patient>.Fail($"Модель {nameof(Patient)} == null");

        if (string.IsNullOrWhiteSpace(patient.Name))
            return Result<Patient>.Fail("Обязательно для заполнения");

        if (string.IsNullOrWhiteSpace(patient.LastName))
            return Result<Patient>.Fail("Обязательно для заполнения");


        return Result<Patient>.Ok(patient);
    }
}