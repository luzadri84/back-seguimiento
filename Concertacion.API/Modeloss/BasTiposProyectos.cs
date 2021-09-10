using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class BasTiposProyectos
    {
        public BasTiposProyectos()
        {
            AppTipoProyectoProponente = new HashSet<AppTipoProyectoProponente>();
        }

        public decimal TipId { get; set; }
        public string TipNombre { get; set; }
        public string TipInstancia { get; set; }
        public decimal VigId { get; set; }

        public virtual AppVigencias Vig { get; set; }
        public virtual ICollection<AppTipoProyectoProponente> AppTipoProyectoProponente { get; set; }
    }
}
