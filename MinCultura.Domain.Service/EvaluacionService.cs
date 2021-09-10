using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCultura.Domain.Service
{
    public class EvaluacionService : IEvaluacionService
    {
        private readonly IEvaluacionBL _evaluacionBL;

        public EvaluacionService(IEvaluacionBL evaluacionsBL)
        {
            _evaluacionBL = evaluacionsBL;
        }

        public Collection<ProyectoDto> GetProyectoByEstado(string estado)
        {
            return _evaluacionBL.GetProyectoByEstado(estado);
        }

        public ProyectoDto GetProyectoById(decimal proId)
        {
            return _evaluacionBL.GetProyectoById(proId);
        }

        public Collection<EvaluacionRequisitosDto> GetProyectoByEvaluacionRequisitos(decimal proId)
        {
            return _evaluacionBL.GetProyectoByEvaluacionRequisitos(proId);
        }

        public bool CrearEvaluacionForma(List<EvaluacionRequisitosDto> evaluacionRequisitos, string userCreo)
        {
            return _evaluacionBL.CrearEvaluacionForma(evaluacionRequisitos, userCreo);
        }


        public RespuestaDto EnviarCorreoSolicitudDocumento(ProyectoDto proyecto)
        {
            return _evaluacionBL.EnviarCorreoSolicitudDocumento(proyecto);
        }

        public bool CambiarEstadoProyecto(decimal proId)
        {
            return _evaluacionBL.CambiarEstadoProyecto(proId);
        }

    }
}
