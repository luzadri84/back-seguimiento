using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class BasZonasGeograficas
    {
        public BasZonasGeograficas()
        {
            AppProponentes = new HashSet<AppProponentes>();
            PresupuestoParametrizacionLineasTope = new HashSet<PresupuestoParametrizacionLineasTope>();
        }

        public string ZonId { get; set; }
        public string ZonNombre { get; set; }
        public string ZonPadreId { get; set; }
        public decimal? ZonPoblacion { get; set; }
        public decimal? ZonPoblacionsinic { get; set; }
        public byte? ZonDistrito { get; set; }
        public double? ZonLatitud { get; set; }
        public double? ZonLongitud { get; set; }
        public string ZonCategoria { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual ICollection<AppProponentes> AppProponentes { get; set; }
        public virtual ICollection<PresupuestoParametrizacionLineasTope> PresupuestoParametrizacionLineasTope { get; set; }
    }
}
