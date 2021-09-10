using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class EnvioCorreos
    {
        public EnvioCorreos()
        {
            AdjuntoCorreos = new HashSet<AdjuntoCorreos>();
        }

        public int Id { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string Remitentes { get; set; }
        public bool Enviado { get; set; }
        public int Intento { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime FechaCreo { get; set; }
        public string Observaciones { get; set; }

        public virtual ICollection<AdjuntoCorreos> AdjuntoCorreos { get; set; }
    }
}
