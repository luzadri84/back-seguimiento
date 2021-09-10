using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class IndicadorLineaCategoriaMunicipioDto
    {
        public decimal IlcmId { get; set; }
        public decimal IndId { get; set; }
        public decimal LinId { get; set; }
        public decimal IdZonCategoria { get; set; }
        public decimal? IlmOrder { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }


    }
}
