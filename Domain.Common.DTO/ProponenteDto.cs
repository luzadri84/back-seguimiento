
using System;
using System.Collections.Generic;

namespace MinCultura.Domain.Common.DTO
{
    public class ProponenteDto
    {
        public decimal ProId { get; set; }
        public string ProRazonSocial { get; set; }
        public string ProNit { get; set; }
        public string ProPrimerNombreRepLegal { get; set; }
        public string ProSegundoNombreRepLegal { get; set; }
        public string ProPrimerApellidoRepLegal { get; set; }
        public string ProSegundoApellidoRepLegal { get; set; }
        public string ProDocumentoIdentidadRepresentanteLegal { get; set; }
        public string ProLugarExpedicionDocumentoRepresentanteLegal { get; set; }
        public string ProDireccionRepresentanteLegal { get; set; }
        public string ProTelefonosRepresentanteLegal { get; set; }
        public string ProTelefonoCelular { get; set; }
        public string ProFaxRepresentanteLegal { get; set; }
        public string ProCorreoElectronicoRepresentanteLegal { get; set; }
        public string ProRegimenTributario { get; set; }
        public string ProGranContribuyente { get; set; }
        public decimal? ProTarifa { get; set; }
        public string ProResponsableIva { get; set; }
        public string ProTarifaIca { get; set; }
        public string ZonId { get; set; }
        public int? TipId { get; set; }
        public string ZonIdExpedicionDocumento { get; set; }
        public string ProBarrioComuna { get; set; }
        public string ProTipoVinculacionPersona { get; set; }
        public string ProDirtrad { get; set; }
        public double? ProLatitud { get; set; }
        public double? ProLongitud { get; set; }
        public string ProEstadoGeo { get; set; }
        public int? ProActualizaPrimeraVez { get; set; }
        public int? DetPropId { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }
        public virtual AppTiposEntidadesDto Tip { get; set; }
        public virtual ICollection<ProyectoDto> AppProyectos { get; set; }
    }
}
