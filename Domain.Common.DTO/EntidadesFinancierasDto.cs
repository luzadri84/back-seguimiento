using System;
namespace MinCultura.Domain.Common.DTO
{
    public class EntidadesFinancierasDto
    {
        public decimal EntId { get; set; }
        public string EntNombre { get; set; }
        public string EntVisible { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
    }
}
