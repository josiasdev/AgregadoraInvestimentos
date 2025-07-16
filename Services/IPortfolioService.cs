using InvestTrack.API.Models;

namespace InvestTrack.API.Services;

public interface IPortfolioService
{
    Task<object> GetPortfolioSummaryAsync(int usuarioId);
}