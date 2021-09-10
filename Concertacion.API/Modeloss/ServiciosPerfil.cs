using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class ServiciosPerfil
    {
        public int ServiciosPerfilid { get; set; }
        public byte Servicioid { get; set; }
        public int Perfilid { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
