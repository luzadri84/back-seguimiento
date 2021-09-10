using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppEvaluacionRequisitos
    {
        public decimal ProId { get; set; }
        public decimal ReqId { get; set; }
        public string PunValor { get; set; }
        public string EvaObservacion { get; set; }
        public DateTime? EvaFecha { get; set; }
        public string PunSolicitud { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppProyectos Pro { get; set; }
        public virtual AppRequisitos Req { get; set; }
    }
}
