using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppRequisitos
    {
        public AppRequisitos()
        {
            AppEvaluacionRequisitos = new HashSet<AppEvaluacionRequisitos>();
        }

        public decimal ReqId { get; set; }
        public decimal VigId { get; set; }
        public string ReqNombre { get; set; }
        public int TipId { get; set; }
        public string ReqCausalRechazo { get; set; }
        public int? ReqOrden { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppVigencias Vig { get; set; }
        public virtual ICollection<AppEvaluacionRequisitos> AppEvaluacionRequisitos { get; set; }
    }
}
