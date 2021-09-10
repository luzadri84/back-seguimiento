using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppEstadoContratacion
    {
        public AppEstadoContratacion()
        {
            AppContratacion = new HashSet<AppContratacion>();
        }

        public decimal EscId { get; set; }
        public string EscNombre { get; set; }

        public virtual ICollection<AppContratacion> AppContratacion { get; set; }
    }
}
