using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppTipoEntidadUsuario
    {
        public string Nit { get; set; }
        public decimal IdVigencia { get; set; }
        public int IdTipoEntidad { get; set; }
        public int? IdDetalleTipoEntidad { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppDetalleTiposEntidades IdDetalleTipoEntidadNavigation { get; set; }
        public virtual AppTiposEntidades IdTipoEntidadNavigation { get; set; }
        public virtual AppVigencias IdVigenciaNavigation { get; set; }
    }
}
