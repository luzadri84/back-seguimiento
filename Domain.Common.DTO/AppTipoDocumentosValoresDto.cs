using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    
    public  class AppTipoDocumentosValoresDto
    {
        public decimal TdvId { get; set; }
        public decimal? TdoId { get; set; }
        public decimal? ProId { get; set; }
        public string TdvNombre { get; set; }
        public int? TdvNumeroPaginas { get; set; }
        public string TdvRutaAdjunto { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public string TdoNs { get; set; }

        public string TdoNombre { get; set; }

        public string TdoObservaciones { get; set; }

    }
}
