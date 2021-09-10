using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("CON_SEGUIMIENTOS")]
    public partial class ConSeguimientos
    {
        public ConSeguimientos()
        {
            //AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            //AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("SEG_ID", TypeName = "numeric(18, 0)")]
        public decimal? SegId { get; set; }

        [Column("PRO_ID", TypeName = "numeric(18, 0)")]
        public decimal? ProId { get; set; }
       
        [Column("ACT_ID", TypeName = "numeric(18, 0)")]
        public decimal? ActId { get; set; }

        [Column("SEG_OBSERVACION")]
        public string SegObservacion { get; set; }

        [Column("USU_CREO")]
        public string UsuCreo { get; set; }

        [Column("USU_MODIFICO")]
        public string UsuModifico { get; set; }

        [Column("SEG_FECHA_CREO", TypeName = "DateTime")]
        public DateTime? SegFechaCreo { get; set; }
        [Column("SEG_FECHA_SEGUIMIENTO", TypeName = "DateTime")]
        public DateTime? SegFechaSeguimiento { get; set; }

        [Column("SEG_FECHA_MODIFICO", TypeName = "DateTime")]
        public DateTime? SegFechaModifico { get; set; }

        [Column("SEG_MOTIVO_VISITA_NO_REALIZADA", TypeName = "int")]
        public int? SegMotivoVisitaNoRealizada { get; set; }
        [Column("SEG_ESTADO", TypeName = "int")]
        public int? SegEstado { get; set; }





        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
