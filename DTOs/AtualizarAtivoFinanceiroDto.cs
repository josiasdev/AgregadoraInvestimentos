
using System.ComponentModel.DataAnnotations;

namespace InvestTrack.API.DTOs
{
    public class AtualizarAtivoFinanceiroDto
    {
        [Required]
        public string Ticker { get; set; }

        [Required]
        public string NomeEmpresa { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        public decimal PrecoMedioCompra { get; set; }
    }
}