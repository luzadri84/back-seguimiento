using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_COMPONENTES")]
    public partial class AppComponentes
    {
        [Key]
        [Column("COM_ID", TypeName = "numeric(18, 0)")]
        public decimal ComId { get; set; }
        [Column("COM_JUSTIFICACION", TypeName = "text")]
        public string ComJustificacion { get; set; }
        [Column("COM_DESCRIPCION", TypeName = "text")]
        public string ComDescripcion { get; set; }
        [Column("COM_OBJETIVO_GENERAL", TypeName = "text")]
        public string ComObjetivoGeneral { get; set; }
        [Column("COM_OBJETIVOS_ESPECIFICOS", TypeName = "text")]
        public string ComObjetivosEspecificos { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal? ProId { get; set; }
        [Column("COM_EMPLEOS_DESCRIPCION", TypeName = "text")]
        public string ComEmpleosDescripcion { get; set; }
        [Column("COM_EMPLEOS_INDIRECTOS", TypeName = "numeric(18, 0)")]
        public decimal? ComEmpleosIndirectos { get; set; }
        [Column("COM_EMPLEOS_DIRECTOS_TERMINO_FIJO", TypeName = "numeric(18, 0)")]
        public decimal? ComEmpleosDirectosTerminoFijo { get; set; }
        [Column("COM_EMPLEOS_DIRECTOS_TERMINO_INDEFINIDO", TypeName = "numeric(18, 0)")]
        public decimal? ComEmpleosDirectosTerminoIndefinido { get; set; }
        [Column("COM_EMPLEOS_DIRECTOS_TERMINO_NOMBRAMIENTOS", TypeName = "numeric(18, 0)")]
        public decimal? ComEmpleosDirectosTerminoNombramientos { get; set; }
        [Column("COM_EMPLEOS_TOTAL", TypeName = "numeric(18, 0)")]
        public decimal? ComEmpleosTotal { get; set; }
        [Column("COM_FECHA_INICIO_FESTIVAL", TypeName = "datetime")]
        public DateTime? ComFechaInicioFestival { get; set; }
        [Column("COM_FECHA_FINAL_FESTIVAL", TypeName = "datetime")]
        public DateTime? ComFechaFinalFestival { get; set; }
        [Column("COM_METAS", TypeName = "text")]
        public string ComMetas { get; set; }
        [Column("COM_TRAYECTORIA_PROYECTO", TypeName = "text")]
        public string ComTrayectoriaProyecto { get; set; }
        [Column("COM_METAS_B", TypeName = "text")]
        public string ComMetasB { get; set; }
        [Column("COM_METAS_C", TypeName = "text")]
        public string ComMetasC { get; set; }
        [Column("COM_METAS_D", TypeName = "text")]
        public string ComMetasD { get; set; }
        [Column("COM_METAS_E", TypeName = "text")]
        public string ComMetasE { get; set; }
        [Column("COM_METAS_F", TypeName = "text")]
        public string ComMetasF { get; set; }
        [Column("COM_TRAYECTORIA_ANTIGUOS_1", TypeName = "text")]
        public string ComTrayectoriaAntiguos1 { get; set; }
        [Column("COM_TRAYECTORIA_ANTIGUOS_2", TypeName = "text")]
        public string ComTrayectoriaAntiguos2 { get; set; }
        [Column("COM_TRAYECTORIA_ANTIGUOS_3", TypeName = "text")]
        public string ComTrayectoriaAntiguos3 { get; set; }
        [Column("COM_TRAYECTORIA_ANTIGUOS_4", TypeName = "text")]
        public string ComTrayectoriaAntiguos4 { get; set; }
        [Column("COM_TRAYECTORIA_ANTIGUOS_5", TypeName = "text")]
        public string ComTrayectoriaAntiguos5 { get; set; }
        [Column("COM_TRAYECTORIA_NUEVOS_1", TypeName = "text")]
        public string ComTrayectoriaNuevos1 { get; set; }
        [Column("COM_TRAYECTORIA_NUEVOS_2", TypeName = "text")]
        public string ComTrayectoriaNuevos2 { get; set; }
        [Column("COM_TRAYECTORIA_NUEVOS_3", TypeName = "text")]
        public string ComTrayectoriaNuevos3 { get; set; }
        [Column("COM_TRAYECTORIA_NUEVOS_4", TypeName = "text")]
        public string ComTrayectoriaNuevos4 { get; set; }
        [Column("COM_TRAYECTORIA_NUEVOS_5", TypeName = "text")]
        public string ComTrayectoriaNuevos5 { get; set; }
        [Column("COM_TRAYECTORIA_SELECCION")]
        [StringLength(5)]
        public string ComTrayectoriaSeleccion { get; set; }
        [Column("COM_JUSTIFICACION_2", TypeName = "text")]
        public string ComJustificacion2 { get; set; }
        [Column("COM_EMPLEOS_DESCRIPCION_2", TypeName = "text")]
        public string ComEmpleosDescripcion2 { get; set; }
        [Column("COM_TRAYECTORIA_NUEVOS_4B", TypeName = "text")]
        public string ComTrayectoriaNuevos4b { get; set; }
        [Column("COM_TRAYECTORIA_ANTIGUOS_5B", TypeName = "text")]
        public string ComTrayectoriaAntiguos5b { get; set; }
        [Required]
        [Column("USU_CREO")]
        [StringLength(100)]
        public string UsuCreo { get; set; }
        [Column("USU_MODIFICO")]
        [StringLength(100)]
        public string UsuModifico { get; set; }
        [Column("FEC_CREO", TypeName = "datetime")]
        public DateTime? FecCreo { get; set; }
        [Column("FEC_MODIFICO", TypeName = "datetime")]
        public DateTime? FecModifico { get; set; }

        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppComponentes))]
        public virtual AppProyectos Pro { get; set; }
    }
}
