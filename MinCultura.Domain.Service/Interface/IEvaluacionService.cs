using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Service.Interface
{
    public interface IEvaluacionService
    {
        Collection<ProyectoDto> GetProyectoByEstado(string estado);
        Collection<EvaluacionRequisitosDto> GetProyectoByEvaluacionRequisitos(decimal proId);
        ProyectoDto GetProyectoById(decimal proId);
        bool CrearEvaluacionForma(List<EvaluacionRequisitosDto> evaluacionRequisitos, string userCreo);
        RespuestaDto EnviarCorreoSolicitudDocumento(ProyectoDto proyecto);
        bool CambiarEstadoProyecto(decimal proId);
    }
}
