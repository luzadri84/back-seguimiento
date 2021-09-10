using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class PlantillaCorreos
    {
        public string Codigoplantillacorreos { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
    }
}
