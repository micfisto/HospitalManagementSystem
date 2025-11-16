using Hospital.BusinessLogic.Interfaces;
using Models.Patients;

namespace Hospital.BusinessLogic.PatientRules;

public class PatientSexRule:IRule<Patient>
{
    public Result<Patient> Check(Patient? patient)
    {
        if(patient==null)
            return Result<Patient>.Fail($"Модель {nameof(Patient)} == null");
        
        if(!Enum.IsDefined(typeof(Sex), patient.Sex))
            return Result<Patient>.Fail("Содержит некорректное значение");
        
        return Result<Patient>.Ok(patient);
    }
}