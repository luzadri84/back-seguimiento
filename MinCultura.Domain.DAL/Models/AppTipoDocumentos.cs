using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_TIPO_DOCUMENTOS")]
    public partial class AppTipoDocumentos
    {
        public AppTipoDocumentos()
        {
            AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("TDO_ID", TypeName = "numeric(18, 0)")]
        public decimal TdoId { get; set; }
        [Column("TDO_NOMBRE")]
        [StringLength(2000)]
        public string TdoNombre { get; set; }
        [Column("TDO_OBSERVACION")]
        [StringLength(1000)]
        public string TdoObservacion { get; set; }
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

        [InverseProperty("Tdo")]
        public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        [InverseProperty("Tdo")]
        public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
