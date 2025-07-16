using InvestTrack.API.Models;
namespace InvestTrack.API.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario> GetByIdAsync(int id);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
    Task DeleteAsync(int id);
}