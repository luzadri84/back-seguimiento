using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class BasEntidadesFinancieras
    {
        public BasEntidadesFinancieras()
        {
            AppProyectos = new HashSet<AppProyectos>();
        }

        public decimal EntId { get; set; }
        public string EntNombre { get; set; }
        public string EntVisible { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual ICollection<AppProyectos> AppProyectos { get; set; }
    }
}
