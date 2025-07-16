namespace InvestTrack.API.Models;

public class Usuario
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public List<AtivoFinanceiro> Portfolio { get; set; } = new List<AtivoFinanceiro>();
}