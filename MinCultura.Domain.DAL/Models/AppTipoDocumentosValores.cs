using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_TIPO_DOCUMENTOS_VALORES")]
    public partial class AppTipoDocumentosValores
    {
        [Key]
        [Column("TDV_ID", TypeName = "numeric(18, 0)")]
        public decimal TdvId { get; set; }
        [Column("TDO_ID", TypeName = "numeric(18, 0)")]
        public decimal? TdoId { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal? ProId { get; set; }
        [Column("TDV_NOMBRE")]
        [StringLength(1000)]
        public string TdvNombre { get; set; }
        [Column("TDV_NUMERO_PAGINAS")]
        public int? TdvNumeroPaginas { get; set; }
        [Column("TDV_RUTA_ADJUNTO")]
        public string TdvRutaAdjunto { get; set; }
        [Required]
        [Column("USU_CREO")]
        [StringLength(100)]
        public string UsuCreo { get; set; }
        [Column("USU_MODIFICO")]
        [StringLength(100)]
        public string UsuModifico { get; set; }
        [Column("FEC_CREO", TypeName = "datetime")]
        public DateTime FecCreo { get; set; }
        [Column("FEC_MODIFICO", TypeName = "datetime")]
        public DateTime? FecModifico { get; set; }

        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppTipoDocumentosValores))]
        public virtual AppProyectos Pro { get; set; }
        [ForeignKey(nameof(TdoId))]
        [InverseProperty(nameof(AppTipoDocumentos.AppTipoDocumentosValores))]
        public virtual AppTipoDocumentos Tdo { get; set; }
    }
}
