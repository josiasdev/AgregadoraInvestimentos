using InvestTrack.API.Models;

namespace InvestTrack.API.Repositories
{
    public interface IAtivoFinanceiroRepository
    {
        /// <summary>
        /// Busca um ativo financeiro específico pelo seu ID.
        /// </summary>
        Task<AtivoFinanceiro> GetByIdAsync(int id);
        
        /// <summary>
        /// Busca todos os ativos financeiros pertencentes a um usuário específico.
        /// </summary>
        Task<IEnumerable<AtivoFinanceiro>> GetByUsuarioIdAsync(int usuarioId);
        
        /// <summary>
        /// Adiciona um novo ativo financeiro ao banco de dados.
        /// </summary>
        Task<AtivoFinanceiro> AddAsync(AtivoFinanceiro ativo);
        
        /// <summary>
        /// Atualiza um ativo financeiro existente.
        /// </summary>
        Task UpdateAsync(AtivoFinanceiro ativo);

        /// <summary>
        /// Remove um ativo financeiro do banco de dados pelo seu ID.
        /// </summary>
        Task DeleteAsync(int id);
    }    
}