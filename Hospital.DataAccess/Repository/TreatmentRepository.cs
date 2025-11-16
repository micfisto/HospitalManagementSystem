using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DoctorAppointments;

namespace Hospital.DataAccess.Repository;

public class TreatmentRepository:IRepository<Treatment>
{
    private HospitalContext _context;

    public TreatmentRepository(HospitalContext context)
    {
        _context = context;
    }
    
    public async Task<Treatment?> GetByIdAsync(Guid id)
    {
        return await _context.Treatments.FirstOrDefaultAsync(treatment => treatment.Id==id);
    }

    public async Task<List<Treatment>> GetAllAsync()
    {
        return await _context.Treatments.ToListAsync();
    }

    public async Task AddAsync(Treatment treatment)
    {
        _context.Treatments.Add(treatment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Treatment treatment)
    {
        _context.Treatments.Add(treatment);
        await _context.SaveChangesAsync();    }

    public async Task DeleteAsync(Guid id)
    {
        var treatment = await _context.Treatments.FirstOrDefaultAsync(treatment => treatment.Id == id);
        if (treatment != null)
        {
            _context.Treatments.Remove(treatment);
            await _context.SaveChangesAsync();
        }
    }
}