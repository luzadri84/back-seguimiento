using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class ValoresIndicadorLineaCategoriaMunicipioDto
    {
        public decimal VilcmId { get; set; }
        public decimal IlcmId { get; set; }
        public decimal ProId { get; set; }
        public decimal? ValValor { get; set; }
        public string ValValorTexto { get; set; }
        public DateTime? FecModifico { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }


    }
}
