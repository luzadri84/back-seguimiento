using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppRangos
    {
        public AppRangos()
        {
            AppPuntajeProyecto = new HashSet<AppPuntajeProyecto>();
        }

        public decimal RanId { get; set; }
        public decimal VarId { get; set; }
        public string RanDescripcion { get; set; }
        public string RanPuntajeAbierto { get; set; }
        public decimal? RanPuntaje { get; set; }
        public decimal? RanMinimo { get; set; }
        public decimal? RanMaximo { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppVariables Var { get; set; }
        public virtual ICollection<AppPuntajeProyecto> AppPuntajeProyecto { get; set; }
    }
}
