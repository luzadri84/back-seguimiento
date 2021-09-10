using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    
    public  class AppPresupuestoDetalleTipoDto
    {
        public decimal AptId { get; set; }

        public string AptDescripcion { get; set; }

        public decimal? AptOrden { get; set; }

        public decimal? VIG_ID { get; set; }

        public int ATT_ID { get; set; }

        public int TCP_ID { get; set; }
    }
}
