using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppCausalesRechazo
    {
        public decimal VigId { get; set; }
        public decimal CauId { get; set; }
        public string CauDescripcion { get; set; }
        public string CauNombre { get; set; }

        public virtual AppVigencias Vig { get; set; }
    }
}
