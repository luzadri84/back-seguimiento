using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    
    public  class ResultadoDTO
    {
        public int PRO_ID { get; set; }
        public string PRO_NUMERO_RADICACION { get; set; }

        public string PRO_NOMBRE { get; set; }

        public string PRO_RAZON_SOCIAL  { get; set; }

        public string PRO_FECHA_INICIAL { get; set; }

        public string PRO_FECHA_FINAL { get; set; }

        public string PRO_ESTADO { get; set; }

        public string PRO_OBSERVACIONES { get; set; }

        public string LIN_NOMBRE { get; set; }

        public string Ubicacion { get; set; }

        public string Area { get; set; }



    }
}
