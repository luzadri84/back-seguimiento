using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class PreguntaUsuario
    {
        public long Id { get; set; }
        public int Cuentausuarioid { get; set; }
        public int Idpregunta { get; set; }
        public string Respuesta { get; set; }
        public bool Estado { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual Cuentausuario Cuentausuario { get; set; }
        public virtual PreguntaSeguridad IdpreguntaNavigation { get; set; }
    }
}
