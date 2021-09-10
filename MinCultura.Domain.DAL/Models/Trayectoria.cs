using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("TRAYECTORIA")]
    public partial class Trayectoria
    {
        public Trayectoria()
        {
            //AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            //AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("TRA_ID", TypeName = "int")]
        public int TRA_ID { get; set; }

        [Column("TRA_PREGUNTA")]
        //[StringLength(2000)]
        public string TRA_PREGUNTA { get; set; }

        [Column("TTR_ID")]
        //[StringLength(1000)]
        public int TTR_ID { get; set; }

        //[Required]
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        //[StringLength(100)]
        public decimal VIG_ID { get; set; }

        

        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
