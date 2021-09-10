using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class CronogramaDto
    {
        public decimal CprId { get; set; }
        public DateTime CprFechaInicio { get; set; }
        public DateTime CprFechaFinal { get; set; }
        public decimal ProId { get; set; }
        public string CprActividad { get; set; }
        public string CprMeta { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
    }
}
