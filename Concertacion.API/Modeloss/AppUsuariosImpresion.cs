using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppUsuariosImpresion
    {
        public int Id { get; set; }
        public int Cuentausuarioid { get; set; }
        public decimal ProId { get; set; }
        public DateTime? FechaImpresion { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual Cuentausuario Cuentausuario { get; set; }
        public virtual AppProyectos Pro { get; set; }
    }
}
