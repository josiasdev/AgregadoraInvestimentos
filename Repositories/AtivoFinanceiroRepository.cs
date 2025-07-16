using InvestTrack.API.Data;
using InvestTrack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestTrack.API.Repositories
{
    public class AtivoFinanceiroRepository : IAtivoFinanceiroRepository
    {
        private readonly InvestTrackContext _context;
        public AtivoFinanceiroRepository(InvestTrackContext context)
        {
            _context = context;
        }
        public async Task<AtivoFinanceiro> GetByIdAsync(int id)
        {
            return await _context.AtivosFinanceiros.FindAsync(id);
        }
        public async Task<IEnumerable<AtivoFinanceiro>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await _context.AtivosFinanceiros
                .Where(a => a.UsuarioId == usuarioId)
                .ToListAsync();
        }
        
        public async Task<AtivoFinanceiro> AddAsync(AtivoFinanceiro ativo)
        {
            await _context.AtivosFinanceiros.AddAsync(ativo);
            await _context.SaveChangesAsync();
            return ativo;
        }

        public async Task UpdateAsync(AtivoFinanceiro ativo)
        {
            _context.AtivosFinanceiros.Update(ativo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ativo = await GetByIdAsync(id);
            if (ativo != null)
            {
                _context.AtivosFinanceiros.Remove(ativo);
                await _context.SaveChangesAsync();
            }
        }
    }
}