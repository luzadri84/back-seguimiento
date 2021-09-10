using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppPresupuestoDetalleTipo
    {
        public AppPresupuestoDetalleTipo()
        {
            AppPresupuestoDetalle = new HashSet<AppPresupuestoDetalle>();
        }

        public decimal AptId { get; set; }
        public string AptDescripcion { get; set; }
        public decimal? AptOrden { get; set; }
        public decimal? VigId { get; set; }
        public int? AttId { get; set; }
        public int? TcpId { get; set; }

        public virtual ICollection<AppPresupuestoDetalle> AppPresupuestoDetalle { get; set; }
    }
}
