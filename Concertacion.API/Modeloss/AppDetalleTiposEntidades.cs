using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppDetalleTiposEntidades
    {
        public AppDetalleTiposEntidades()
        {
            AppTipoEntidadUsuario = new HashSet<AppTipoEntidadUsuario>();
        }

        public int DetId { get; set; }
        public int TipId { get; set; }
        public string DetNombre { get; set; }
        public short? DetNumeroProyectos { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppTiposEntidades Tip { get; set; }
        public virtual ICollection<AppTipoEntidadUsuario> AppTipoEntidadUsuario { get; set; }
    }
}
