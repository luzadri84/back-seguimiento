using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppRadicadoProyectos
    {
        public int NumeroRadicado { get; set; }
        public decimal ProId { get; set; }
        public decimal VigId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string RadicadoProyecto { get; set; }

        public virtual AppProyectos Pro { get; set; }
        public virtual AppVigencias Vig { get; set; }
    }
}
