using Models.DoctorAppointments;

namespace Interfaces;

public interface IDoctorAppointmentRepository
{
    Task<DoctorAppointment?> GetIdAsync(Guid id);
    Task<List<DoctorAppointment>> GetAllAsync();
    Task AddAsync(DoctorAppointment appointment);
    Task UpdateAsync(DoctorAppointment appointment);
    Task DeleteAsync(Guid id);
}