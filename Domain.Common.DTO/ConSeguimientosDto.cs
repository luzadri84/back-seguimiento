using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class ConSeguimientosDto
    {
        public decimal? SegId { get; set; }

        public decimal? ProId { get; set; }
       
        public decimal? ActId { get; set; }

        public string SegObservacion { get; set; }

        public string UsuCreo { get; set; }

        public string UsuModifico { get; set; }

        public DateTime? SegFechaCreo { get; set; }
        public DateTime? SegFechaSeguimiento { get; set; }

        public DateTime? SegFechaModifico { get; set; }

        public int? SegMotivoVisitaNoRealizada { get; set; }
        public int? SegEstado { get; set; }

    }
}
