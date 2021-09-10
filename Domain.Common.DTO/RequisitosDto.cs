using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class RequisitosDto
    {
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
    }
}
