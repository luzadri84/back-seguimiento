using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class PerfilesCuentausuario
    {
        public int PerfilesCuentausuarioid { get; set; }
        public int Perfilid { get; set; }
        public int Cuentausuarioid { get; set; }

        public virtual Cuentausuario Cuentausuario { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
