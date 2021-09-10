using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppRegistroRechazados
    {
        public decimal ReqId { get; set; }
        public decimal? ProId { get; set; }
        public decimal? CauId { get; set; }
        public string ProObservaciones { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppProyectos Pro { get; set; }
    }
}
