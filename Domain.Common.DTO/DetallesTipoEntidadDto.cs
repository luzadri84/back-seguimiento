using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class DetallesTipoEntidadDto
    {
        public int DetId { get; set; }
        public int TipId { get; set; }
        public string DetNombre { get; set; }
        public short? DetNumeroProyectos { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
    }
}
