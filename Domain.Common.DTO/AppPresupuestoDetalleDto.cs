using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    
    public  class AppPresupuestoDetalleDto
    {
        public AppPresupuestoDetalleDto()
        {

        }
        public decimal? PdeId { get; set; }
        public decimal? PdeValorTotal { get; set; }
        public decimal? PdeRecursosMunicipio { get; set; }
        public decimal? PdeRecursosDepartmento { get; set; }
        public decimal? PdeRecursosMinisterio { get; set; }
        public decimal? PdeIngresosPropios { get; set; }
        public decimal? PdeOtrosRecursos { get; set; }
        public decimal? ProId { get; set; }
        public decimal? AptId { get; set; }

        public string PdeDetalleOtrosRecursos { get; set; }

        public string UsuCreo { get; set; }
        
        public string UsuModifico { get; set; }
        
        public DateTime? FecCreo { get; set; }
        
        public DateTime? FecModifico { get; set; }

        public string APT_DESCRIPCION { get; set; }
        public int TCP_ID { get; set; }

        public string ATT_DESCRIPCION { get; set; }

        public int ATT_ID { get; set; }

        public decimal? APT_ORDEN { get; set; }

        public decimal? VALOR_TOPE_PRESUPUESTO { get; set; }

        public bool TIP_RECURSOS_ENTIDAD { get; set; }
    }
}
