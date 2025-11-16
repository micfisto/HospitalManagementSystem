using Hospital.BusinessLogic;
using Models.Departments;
using Models.Patients;

namespace Hospital.ServiceLayer.Interfaces;

public interface IPatientService
{
    Task <Result<Patient>> CreatePatient(Patient patient);
    Task <Result<Patient>> DischargedPatient(Patient patient);
    Task <List<DepartmentType>> GetAllowedDepartments(Patient patient);
}