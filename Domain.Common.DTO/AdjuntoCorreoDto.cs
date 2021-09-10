using System;

namespace MinCultura.Domain.Common.DTO
{
    public class AdjuntoCorreoDto
    {
        public int Id { get; set; }
        public int IdEnvio { get; set; }

        public string RutaAdjunto { get; set; }

        public string NombreAdjunto { get; set; }

        public DateTime FechaCreo { get; set; }

        public virtual EnvioCorreosDto EnvioCorreos { get; set; }
    }
}
