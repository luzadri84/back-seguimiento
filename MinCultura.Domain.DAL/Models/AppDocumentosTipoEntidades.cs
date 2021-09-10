using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_DOCUMENTOS_TIPO_ENTIDADES")]
    public partial class AppDocumentosTipoEntidades
    {
        [Key]
        [Column("TDO_ID", TypeName = "numeric(18, 0)")]
        public decimal TdoId { get; set; }
        [Key]
        [Column("TIP_ID")]
        public int TipId { get; set; }
        [Column("TDO_NS")]
        [StringLength(20)]
        public string TdoNs { get; set; }
        [Column("TDO_ORDEN", TypeName = "numeric(18, 0)")]
        public decimal? TdoOrden { get; set; }
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

        [Column("OBLIGATORIO", TypeName = "bit")]
        public bool Obligatorio { get; set; }
        
        [ForeignKey(nameof(TdoId))]
        [InverseProperty(nameof(AppTipoDocumentos.AppDocumentosTipoEntidades))]
        public virtual AppTipoDocumentos Tdo { get; set; }
        [ForeignKey(nameof(TipId))]
        [InverseProperty(nameof(AppTiposEntidades.AppDocumentosTipoEntidades))]
        public virtual AppTiposEntidades Tip { get; set; }
    }
}
