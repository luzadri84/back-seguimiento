using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AdjuntoCorreos
    {
        public int Id { get; set; }
        public int IdEnvio { get; set; }
        public string RutaAdjunto { get; set; }
        public string NombreAdjunto { get; set; }
        public DateTime FechaCreo { get; set; }

        public virtual EnvioCorreos IdEnvioNavigation { get; set; }
    }
}
