using Hospital.BusinessLogic.Interfaces;
using Models.Patients;

namespace Hospital.BusinessLogic.PatientRules;

public class PatientDischargedRule : IRule<Patient>
{
    public Result<Patient> Check(Patient? patient)
    {
        if (patient == null)
            return Result<Patient>.Fail($"Модель {nameof(Patient)} == null");

        if (patient.IsDischarged)
            return Result<Patient>.Fail("Пациент уже выписан");
        
        patient.IsDischarged = true;

        return Result<Patient>.Ok(patient);
    }
}