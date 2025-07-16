namespace InvestTrack.API.Models;

public class AtivoFinanceiro
{
    public int Id { get; set; }
    public string Ticker { get; set; } // Ex: "PETR4", "MXRF11"
    public string NomeEmpresa { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoMedioCompra { get; set; }
    public int UsuarioId { get; set; } // Chave estrangeira
}