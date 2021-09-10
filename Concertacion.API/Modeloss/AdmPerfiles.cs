using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AdmPerfiles
    {
        public decimal PerId { get; set; }
        public string PerNombre { get; set; }
        public string PerDescripcion { get; set; }
        public string PerTipo { get; set; }
        public string PerEstado { get; set; }
        public DateTime PerFechaCreacion { get; set; }
        public DateTime? PerFechaActualizacion { get; set; }
    }
}
