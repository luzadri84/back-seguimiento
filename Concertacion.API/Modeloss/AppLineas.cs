using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppLineas
    {
        public AppLineas()
        {
            AppIndicadoresLinea = new HashSet<AppIndicadoresLinea>();
            AppTemas = new HashSet<AppTemas>();
            AppVariables = new HashSet<AppVariables>();
            PresupuestoParametrizacionLineasTope = new HashSet<PresupuestoParametrizacionLineasTope>();
        }

        public decimal LinId { get; set; }
        public decimal VigId { get; set; }
        public string LinNombre { get; set; }
        public string LinDescripcion { get; set; }
        public int? LinDuracionMinima { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual ICollection<AppIndicadoresLinea> AppIndicadoresLinea { get; set; }
        public virtual ICollection<AppTemas> AppTemas { get; set; }
        public virtual ICollection<AppVariables> AppVariables { get; set; }
        public virtual ICollection<PresupuestoParametrizacionLineasTope> PresupuestoParametrizacionLineasTope { get; set; }
    }
}
