using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppActividadesObligatorias
    {
        public AppActividadesObligatorias()
        {
            AppProyectoActividadesObligatorias = new HashSet<AppProyectoActividadesObligatorias>();
        }

        public decimal ActId { get; set; }
        public string ActActividad { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual ICollection<AppProyectoActividadesObligatorias> AppProyectoActividadesObligatorias { get; set; }
    }
}
