using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppTiposEntidades
    {
        public AppTiposEntidades()
        {
            AppDetalleTiposEntidades = new HashSet<AppDetalleTiposEntidades>();
            AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            AppProponentes = new HashSet<AppProponentes>();
            AppTipoEntidadUsuario = new HashSet<AppTipoEntidadUsuario>();
        }

        public int TipId { get; set; }
        public string TipNombre { get; set; }
        public decimal VigId { get; set; }
        public decimal TipTipId { get; set; }
        public short? TipNumeroProyectos { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
        public bool? TipRecursosPropios { get; set; }
        public bool? TipRecursosEntidad { get; set; }

        public virtual ICollection<AppDetalleTiposEntidades> AppDetalleTiposEntidades { get; set; }
        public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        public virtual ICollection<AppProponentes> AppProponentes { get; set; }
        public virtual ICollection<AppTipoEntidadUsuario> AppTipoEntidadUsuario { get; set; }
    }
}
