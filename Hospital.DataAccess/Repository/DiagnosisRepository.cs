using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Diagnoses;

namespace Hospital.DataAccess.Repository;

public class DiagnosisRepository : IRepository<Diagnosis>
{
    private HospitalContext _context;

    public DiagnosisRepository(HospitalContext context)
    {
        _context = context;
    }

    public async Task<Diagnosis?> GetByIdAsync(Guid id)
    {
        return await _context.Diagnoses.Include(diagnosis => diagnosis.Symptoms)
            .FirstOrDefaultAsync(diagnosis => diagnosis.Id == id);    }

    public async Task<List<Diagnosis>> GetAllAsync()
    {
        return await _context.Diagnoses.Include(diagnosis => diagnosis.Symptoms).ToListAsync();
    }

    public async Task AddAsync(Diagnosis diagnosis)
    {
        _context.Diagnoses.Add(diagnosis);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Diagnosis diagnosis)
    {
        _context.Diagnoses.Update(diagnosis);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var diagnosis = await _context.Diagnoses.FirstOrDefaultAsync(diagnosis => diagnosis.Id == id);
        if (diagnosis != null)
        {
            _context.Diagnoses.Remove(diagnosis);
            await _context.SaveChangesAsync();
        }
    }
}