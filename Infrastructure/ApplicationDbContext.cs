using Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Paste> Pastes { get; set; }
}