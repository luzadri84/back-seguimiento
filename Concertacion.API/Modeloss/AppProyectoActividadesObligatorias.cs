using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppProyectoActividadesObligatorias
    {
        public decimal PaoId { get; set; }
        public decimal ProId { get; set; }
        public decimal ActId { get; set; }
        public DateTime? ActFechaInicio { get; set; }
        public DateTime? ActFechaFinal { get; set; }
        public DateTime? FecModifico { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }

        public virtual AppActividadesObligatorias Act { get; set; }
        public virtual AppProyectos Pro { get; set; }
    }
}
