using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Common.DTO
{
    public class FormularioBDto
    {
        public ProyectoDto Proyecto { get; set; }

        public List<TemasProyectosDto> TemasbyProyectos { get; set; }

        public ComponentesDto Componentes { get; set; }

        public List<CronogramaDto> Cronograma { get; set; }

        public List<ProyectoActividadesObligatoriasDto> ProyectoActividadesObligatorias { set; get; }

        public List<ValoresIndicadorDto> ValoresIndicador { get; set; }

        public List<ValoresIndicadorLineaCategoriaMunicipioDto> ValoresIndicadorLineaCategoriaMunicipio { get; set; }
    }
}
