using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class PresupuestoParametrizacionLineasTope
    {
        public int PplId { get; set; }
        public string ZonId { get; set; }
        public decimal? LinId { get; set; }
        public decimal? ValorTopePresupuesto { get; set; }

        public virtual AppLineas Lin { get; set; }
        public virtual BasZonasGeograficas Zon { get; set; }
    }
}
