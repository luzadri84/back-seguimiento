using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppProyectosCronograma
    {
        public decimal CprId { get; set; }
        public DateTime? CprFechaInicio { get; set; }
        public DateTime? CprFechaFinal { get; set; }
        public decimal? ProId { get; set; }
        public string CprActividad { get; set; }
        public string CprMeta { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppProyectos Pro { get; set; }
    }
}
