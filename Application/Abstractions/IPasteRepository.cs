using Application.Models;

namespace Application.Abstractions;

public interface IPasteRepository
{
    Task<Paste> AddAsync(Paste paste);
    Task<Paste?> GetByIdAsync(Guid id);
    Task<bool> DeleteAsync(Guid id);
    Task<Paste?> UpdateAsync(Guid id, Paste updatePaste);
}