using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppPuntajeProyecto
    {
        public decimal RanId { get; set; }
        public decimal ProId { get; set; }
        public decimal? PunValor { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppRangos Ran { get; set; }
    }
}
