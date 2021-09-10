using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class TipoTrayectoria
    {
        public int TtrId { get; set; }
        public string TtrNombre { get; set; }
        public int? TtrActivo { get; set; }
    }
}
