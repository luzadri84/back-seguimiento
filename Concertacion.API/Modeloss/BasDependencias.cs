using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class BasDependencias
    {
        public BasDependencias()
        {
            AppContratacion = new HashSet<AppContratacion>();
        }

        public decimal DepId { get; set; }
        public string DepNombre { get; set; }
        public string DepDireccion { get; set; }
        public string DepTelefonos { get; set; }
        public decimal? SecId { get; set; }
        public decimal? AreId { get; set; }

        public virtual ICollection<AppContratacion> AppContratacion { get; set; }
    }
}
