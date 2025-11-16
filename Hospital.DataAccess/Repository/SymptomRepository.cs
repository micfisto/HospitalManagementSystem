using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Diagnoses;

namespace Hospital.DataAccess.Repository;

public class SymptomRepository:IRepository<Symptom>
{
    private HospitalContext _context;

    public SymptomRepository(HospitalContext context)
    {
        _context = context;
    }
    
    public async Task<Symptom?> GetByIdAsync(Guid id)
    {
        return await _context.Symptoms.FirstOrDefaultAsync(symptom => symptom.Id==id);
    }

    public async Task<List<Symptom>> GetAllAsync()
    {
        return await _context.Symptoms.ToListAsync();
    }

    public async Task AddAsync(Symptom symptom)
    {
        _context.Symptoms.Add(symptom);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Symptom symptom)
    {
        _context.Symptoms.Add(symptom);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(Guid id)
    {
        var symptom = await _context.Symptoms.FirstOrDefaultAsync(symptom => symptom.Id == id);
        if (symptom != null)
        {
            _context.Symptoms.Remove(symptom);
            await _context.SaveChangesAsync();
        }
    }
}