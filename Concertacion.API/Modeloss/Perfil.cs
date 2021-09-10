using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class Perfil
    {
        public Perfil()
        {
            PerfilesCuentausuario = new HashSet<PerfilesCuentausuario>();
            ServiciosPerfil = new HashSet<ServiciosPerfil>();
        }

        public int Perfilid { get; set; }
        public string Perfilnombre { get; set; }
        public string Perfiltipo { get; set; }
        public bool Perfilhabilitado { get; set; }

        public virtual ICollection<PerfilesCuentausuario> PerfilesCuentausuario { get; set; }
        public virtual ICollection<ServiciosPerfil> ServiciosPerfil { get; set; }
    }
}
