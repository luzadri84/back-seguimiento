using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    
    public  class FuncionarioDto
    {
        public int Id { get; set; }
        public short Tipoidentificacionid { get; set; }
        public string Numeroid { get; set; }
        public string Primernombre { get; set; }
        public string Segundonombre { get; set; }
        public string Primerapellido { get; set; }
        public string Segundoapellido { get; set; }
        public string Genero { get; set; }
        public string Nombrecompleto { get; set; }

    }
}
