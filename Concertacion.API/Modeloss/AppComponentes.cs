using System;
using System.Collections.Generic;

namespace Concertacion.API.Modeloss
{
    public partial class AppComponentes
    {
        public decimal ComId { get; set; }
        public string ComJustificacion { get; set; }
        public string ComDescripcion { get; set; }
        public string ComObjetivoGeneral { get; set; }
        public string ComObjetivosEspecificos { get; set; }
        public decimal? ProId { get; set; }
        public string ComEmpleosDescripcion { get; set; }
        public decimal? ComEmpleosIndirectos { get; set; }
        public decimal? ComEmpleosDirectosTerminoFijo { get; set; }
        public decimal? ComEmpleosDirectosTerminoIndefinido { get; set; }
        public decimal? ComEmpleosDirectosTerminoNombramientos { get; set; }
        public decimal? ComEmpleosTotal { get; set; }
        public DateTime? ComFechaInicioFestival { get; set; }
        public DateTime? ComFechaFinalFestival { get; set; }
        public string ComMetas { get; set; }
        public string ComTrayectoriaProyecto { get; set; }
        public string ComMetasB { get; set; }
        public string ComMetasC { get; set; }
        public string ComMetasD { get; set; }
        public string ComMetasE { get; set; }
        public string ComMetasF { get; set; }
        public string ComTrayectoriaAntiguos1 { get; set; }
        public string ComTrayectoriaAntiguos2 { get; set; }
        public string ComTrayectoriaAntiguos3 { get; set; }
        public string ComTrayectoriaAntiguos4 { get; set; }
        public string ComTrayectoriaAntiguos5 { get; set; }
        public string ComTrayectoriaNuevos1 { get; set; }
        public string ComTrayectoriaNuevos2 { get; set; }
        public string ComTrayectoriaNuevos3 { get; set; }
        public string ComTrayectoriaNuevos4 { get; set; }
        public string ComTrayectoriaNuevos5 { get; set; }
        public string ComTrayectoriaSeleccion { get; set; }
        public string ComJustificacion2 { get; set; }
        public string ComEmpleosDescripcion2 { get; set; }
        public string ComTrayectoriaNuevos4b { get; set; }
        public string ComTrayectoriaAntiguos5b { get; set; }
        public string UsuCreo { get; set; }
        public string UsuModifico { get; set; }
        public DateTime FecCreo { get; set; }
        public DateTime? FecModifico { get; set; }

        public virtual AppProyectos Pro { get; set; }
    }
}
