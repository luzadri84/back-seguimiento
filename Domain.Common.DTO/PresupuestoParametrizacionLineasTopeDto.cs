using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    
    public  class PresupuestoParametrizacionLineasTopeDto
    {
        public int PPL_ID { get; set; }

        public string ZON_ID { get; set; }

        public decimal LIN_ID { get; set; }

        public decimal VALOR_TOPE_PRESUPUESTO { get; set; }

    }
}
