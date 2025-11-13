using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.DoctorAppointments;

namespace Hospital.DataAccess.Repository;

public class DoctorAppointmentsRepository : IDoctorAppointmentRepository
{
    private HospitalContext _context;

    public DoctorAppointmentsRepository(HospitalContext context)
    {
        _context = context;
    }

    public async Task<DoctorAppointment?> GetIdAsync(Guid id)
    {
        return await _context.DoctorAppointments.Include(doctorAppointment => doctorAppointment.Doctor)
            .Include(doctorAppointment => doctorAppointment.Patient)
            .FirstOrDefaultAsync(doctorAppointment => doctorAppointment.Id == id);
    }

    public async Task<List<DoctorAppointment>> GetAllAsync()
    {
        return await _context.DoctorAppointments.Include(doctorAppointment => doctorAppointment.Doctor)
            .Include(doctorAppointment => doctorAppointment.Patient).ToListAsync();
    }

    public async Task AddAsync(DoctorAppointment appointment)
    {
        _context.DoctorAppointments.Add(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(DoctorAppointment appointment)
    {
        _context.DoctorAppointments.Update(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var doctorAppointment = await _context.DoctorAppointments.FirstOrDefaultAsync(doctorAppointment => doctorAppointment.Id == id);
        if (doctorAppointment != null)
        {
            _context.DoctorAppointments.Remove(doctorAppointment);
            await _context.SaveChangesAsync();
        }
    }
}