using Microsoft.EntityFrameworkCore;
using InvestTrack.API.Models;

namespace InvestTrack.API.Data;

public class InvestTrackContext : DbContext
{
    public InvestTrackContext(DbContextOptions<InvestTrackContext> options) : base(options) { }
    
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<AtivoFinanceiro> AtivosFinanceiros { get; set; }
}