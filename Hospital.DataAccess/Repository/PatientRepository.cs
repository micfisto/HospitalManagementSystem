using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Patients;

namespace Hospital.DataAccess.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly HospitalContext _context;

    public PatientRepository(HospitalContext context)
    {
        _context = context;
    }

    public async Task<Patient?> GetByIdAsync(Guid id)
    {
        return await _context.Patients.Include(patient => patient.MedicalRecord).FirstOrDefaultAsync(patient => patient.Id==id);
    }

    public async Task<List<Patient>> GetAllAsync()
    {
        return await _context.Patients.Include(patient => patient.Department).ToListAsync();
    }

    public async Task AddAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(patient => patient.Id == id);
        if (patient != null)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
        }
    }
}