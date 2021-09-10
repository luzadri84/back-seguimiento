using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class Logacciones
    {
        public long Logid { get; set; }
        public string Logtipoaccion { get; set; }
        public string Logusuario { get; set; }
        public DateTime Logfecha { get; set; }
        public string Logip { get; set; }
        public string Logkey { get; set; }
        public string Logtraza { get; set; }
    }
}
