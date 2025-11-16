using Models.Departments;
using Models.Patients;

namespace Hospital.BusinessLogic.Interfaces;

public interface IPatientRule
{
    Result<Patient> ValidateForCreate(Patient patient);
    public List<DepartmentType> Hospitalization(Patient patient);
    Result<Patient> DischargedPatient(Patient patient);
}