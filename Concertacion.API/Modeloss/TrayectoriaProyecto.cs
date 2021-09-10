using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class TrayectoriaProyecto
    {
        public int TprId { get; set; }
        public string TprRespuestaTrayectoria { get; set; }
        public int? TraId { get; set; }
        public decimal? ProId { get; set; }
        public DateTime TprFechainsercion { get; set; }

        public virtual AppProyectos Pro { get; set; }
        public virtual Trayectoria Tra { get; set; }
    }
}
