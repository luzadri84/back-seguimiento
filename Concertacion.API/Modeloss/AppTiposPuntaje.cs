using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppTiposPuntaje
    {
        public AppTiposPuntaje()
        {
            AppVariables = new HashSet<AppVariables>();
        }

        public decimal PunId { get; set; }
        public decimal VigId { get; set; }
        public string PunDescripcion { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppVigencias Vig { get; set; }
        public virtual ICollection<AppVariables> AppVariables { get; set; }
    }
}
