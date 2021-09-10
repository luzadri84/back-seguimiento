using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class LineaDto
    {
        public int LinId { get; set; }
        public string LinNombre { get; set; }
        public string LinDescripcion { get; set; }
        public int LinDuracionMinima { get; set; }

    }
}
