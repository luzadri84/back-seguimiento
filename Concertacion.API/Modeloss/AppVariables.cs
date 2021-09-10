using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppVariables
    {
        public AppVariables()
        {
            AppRangos = new HashSet<AppRangos>();
        }

        public decimal VarId { get; set; }
        public decimal PunId { get; set; }
        public decimal? LinId { get; set; }
        public string VarDescripcion { get; set; }
        public string VarFormulado { get; set; }
        public decimal? VarOperando1 { get; set; }
        public decimal? VarOperando2 { get; set; }
        public string VarOperador { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppLineas Lin { get; set; }
        public virtual AppTiposPuntaje Pun { get; set; }
        public virtual ICollection<AppRangos> AppRangos { get; set; }
    }
}
