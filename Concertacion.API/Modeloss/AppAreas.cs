using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppAreas
    {
        public decimal AreId { get; set; }
        public decimal? VigId { get; set; }
        public string AreNombre { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppVigencias Vig { get; set; }
    }
}
