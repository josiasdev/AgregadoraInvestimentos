using InvestTrack.API.Models;
using InvestTrack.API.Repositories;

namespace InvestTrack.API.Services;

public class PortfolioService : IPortfolioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public PortfolioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    public async Task<object> GetPortfolioSummaryAsync(int usuarioId)
    {
        var usuario = await _usuarioRepository.GetByIdWithPortfolioAsync(usuarioId);

        if (usuario == null)
        {
            return null;
        }

        decimal valorTotal = 0;
        var random = new Random();

        var ativosDetalhes = usuario.Portfolio.Select(ativo => 
        {
            decimal precoAtual = (decimal)(random.NextDouble() * 200); // Preço aleatório entre 0 e 200
            decimal valorPosicao = ativo.Quantidade * precoAtual;
            valorTotal += valorPosicao;

            return new 
            {
                Ticker = ativo.Ticker,
                Quantidade = ativo.Quantidade,
                PrecoMedio = ativo.PrecoMedioCompra,
                PrecoAtual = Math.Round(precoAtual, 2),
                ValorTotalPosicao = Math.Round(valorPosicao, 2)
            };
        }).ToList();

        var summary = new 
        {
            UsuarioId = usuario.Id,
            NomeUsuario = usuario.NomeCompleto,
            ValorTotalConsolidado = Math.Round(valorTotal, 2),
            Ativos = ativosDetalhes
        };

        return summary;
    }
}