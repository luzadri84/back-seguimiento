using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class Trayectoria
    {
        public Trayectoria()
        {
            TrayectoriaProyecto = new HashSet<TrayectoriaProyecto>();
        }

        public int TraId { get; set; }
        public string TraPregunta { get; set; }
        public int? TtrId { get; set; }
        public decimal? VigId { get; set; }

        public virtual AppVigencias Vig { get; set; }
        public virtual ICollection<TrayectoriaProyecto> TrayectoriaProyecto { get; set; }
    }
}
