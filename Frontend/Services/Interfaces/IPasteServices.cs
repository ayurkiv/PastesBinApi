using Frontend.Pages;
using Paste = Application.Models.Paste;

namespace Frontend.Services.Interfaces;

public interface IPasteServices
{
    Task<Paste?> GetById(Guid id);
}