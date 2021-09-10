using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class PreguntaSeguridad
    {
        public PreguntaSeguridad()
        {
            PreguntaUsuario = new HashSet<PreguntaUsuario>();
        }

        public int Id { get; set; }
        public string Pregunta { get; set; }
        public bool Estado { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual ICollection<PreguntaUsuario> PreguntaUsuario { get; set; }
    }
}
