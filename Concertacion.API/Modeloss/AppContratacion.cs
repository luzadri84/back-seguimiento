using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppContratacion
    {
        public decimal Id { get; set; }
        public decimal ProId { get; set; }
        public decimal? ConNumeroconvenio { get; set; }
        public DateTime? ConFechainicio { get; set; }
        public DateTime? ConFechafin { get; set; }
        public decimal? ConValorconvenio { get; set; }
        public string ConRegistropresup { get; set; }
        public string ConRegistropresupSN { get; set; }
        public string ConConveniofirmado { get; set; }
        public string ConFormatoA { get; set; }
        public decimal? ConTotalfolios { get; set; }
        public DateTime? ConGarantiaManejoDesde { get; set; }
        public DateTime? ConGarantiaManejoHasta { get; set; }
        public string ConGarantiaManejoOk { get; set; }
        public DateTime? ConGarantiaCumpDesde { get; set; }
        public DateTime? ConGarantiaCumpHasta { get; set; }
        public string ConGarantiaCumpOk { get; set; }
        public DateTime? ConGarantiaSalarioDesde { get; set; }
        public DateTime? ConGarantiaSalarioHasta { get; set; }
        public string ConGarantiaSalarioOk { get; set; }
        public string ConCrp { get; set; }
        public string ConUsuario { get; set; }
        public decimal? DepId { get; set; }
        public decimal? EscId { get; set; }
        public string ConCdp { get; set; }
        public string ConFechacdp { get; set; }
        public string ConActa { get; set; }
        public string ConFechaacta { get; set; }
        public string ConAnexos { get; set; }
        public string ConEvaluacion { get; set; }
        public string ConFormatoB { get; set; }
        public string ConContratando { get; set; }
        public decimal? ConValoradicion { get; set; }
        public string ConCorreeosupervisor { get; set; }
        public string ConCorreofinalizacion { get; set; }
        public string ConFormaPago { get; set; }
        public string ConAbogado { get; set; }
        public DateTime? ConFechasuscripcion { get; set; }
        public string ConLinksecop { get; set; }
        public DateTime? ConFechaLiquidacion { get; set; }
        public DateTime? ConFechaRadContratos { get; set; }
        public DateTime? ConFechaLiqContratos { get; set; }
        public string ConNumProcesoSecop { get; set; }
        public bool? ConNotificado { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual BasDependencias Dep { get; set; }
        public virtual AppEstadoContratacion Esc { get; set; }
        public virtual AppProyectos Pro { get; set; }
    }
}
