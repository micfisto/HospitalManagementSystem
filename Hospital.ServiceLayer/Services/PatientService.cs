using Hospital.BusinessLogic;
using Hospital.BusinessLogic.PatientRules;
using Hospital.ServiceLayer.Interfaces;
using Interfaces;
using Models.Departments;
using Models.Patients;

namespace Hospital.ServiceLayer.Services;

public class PatientService : IPatientService
{
    private readonly PatientRule _patientRule;
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRule = new PatientRule();
        _patientRepository = patientRepository;
    }

    public async Task<Result<Patient>> CreatePatient(Patient patient)
    {
        var result = _patientRule.ValidateForCreate(patient);
        if (!result.Success)
            return result;

        await _patientRepository.AddAsync(patient);
        return Result<Patient>.Ok(patient);
    }

    public async Task<Result<Patient>> DischargedPatient(Patient patient)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(patient.Id);
        if (existingPatient == null)
            return Result<Patient>.Fail("Пациент не найден");
        var result = _patientRule.DischargedPatient(existingPatient);
        if (!result.Success)
            return result;
        await _patientRepository.UpdateAsync(existingPatient);
        return Result<Patient>.Ok(existingPatient);
    }


    public async Task<List<DepartmentType>> GetAllowedDepartments(Patient patient)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(patient.Id);
        if (existingPatient == null)
            return new List<DepartmentType>();
        return _patientRule.Hospitalization(existingPatient);
    }
}