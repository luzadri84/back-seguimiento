using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class ValoresIndicadorDto
    {
        public decimal? ViId { get; set; }
        public decimal IlId { get; set; }
        public decimal ProId { get; set; }
        public decimal? ValValor { get; set; }
        public string ValValorTexto { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

    }
}
