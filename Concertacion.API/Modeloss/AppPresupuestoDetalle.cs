using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppPresupuestoDetalle
    {
        public decimal PdeId { get; set; }
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
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppPresupuestoDetalleTipo Apt { get; set; }
        public virtual AppProyectos Pro { get; set; }
    }
}
