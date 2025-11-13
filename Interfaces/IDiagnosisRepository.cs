using Models.Diagnoses;

namespace Interfaces;

public interface IDiagnosisRepository
{
    Task<Diagnosis?> GetIdAsync(Guid id);
    Task<List<Diagnosis>> GetAllAsync();
    Task AddAsync(Diagnosis diagnosis);
    Task UpdateAsync(Diagnosis diagnosis);
    Task DeleteAsync(Guid id);
}