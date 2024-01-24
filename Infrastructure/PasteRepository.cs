using Application.Abstractions;
using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class PasteRepository(ApplicationDbContext context) : IPasteRepository
{
    public async Task<Paste?> GetByIdAsync(Guid id)
    {
        var paste = await context.Pastes.FirstOrDefaultAsync(p => p.Id == id);
        if (paste != null)
        {
            paste.Views++;
            await context.SaveChangesAsync();
        }
        return paste;
    }

    public async Task<Paste> AddAsync(Paste paste)
    {
        await context.Pastes.AddAsync(paste);
        await context.SaveChangesAsync();
        return paste;
    }


    public async Task<bool> DeleteAsync(Guid id)
    {
        var paste = context.Pastes.FirstOrDefault(p => p.Id == id); //Paste? paste

        if (paste != null)
        {
            context.Pastes.Remove(paste);
            await context.SaveChangesAsync();
            return true;
        }
        else return false;
    }

    public async Task<Paste?> UpdateAsync(Guid id, Paste updatePaste)
    {
        var paste = await context.Pastes.FirstOrDefaultAsync(p => p.Id == id); //Paste? paste
        if (paste != null)
        {
            paste.Content = updatePaste.Content;
            paste.Title = updatePaste.Title;
            return paste;
        }
        else
        {
            return null;
        }
    }
}