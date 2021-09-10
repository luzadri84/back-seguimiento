using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    
    public partial class Resultado
    {
        public Resultado()
        {
            //AppDocumentosTipoEntidades = new HashSet<AppDocumentosTipoEntidades>();
            //AppTipoDocumentosValores = new HashSet<AppTipoDocumentosValores>();
        }

        [Key]
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public int PRO_ID { get; set; }

        [Column("PRO_NUMERO_RADICACION")]
        [NotMapped]
        public string PRO_NUMERO_RADICACION { get; set; }

        [Column("PRO_NOMBRE")]
        [NotMapped]
        public string PRO_NOMBRE { get; set; }

        [Column("PRO_RAZON_SOCIAL")]
        [NotMapped]
        public string PRO_RAZON_SOCIAL { get; set; }

        [Column("PRO_FECHA_INICIAL")]
        [NotMapped]
        public string PRO_FECHA_INICIAL { get; set; }

        [Column("PRO_FECHA_FINAL")]
        [NotMapped]
        public string PRO_FECHA_FINAL { get; set; }

        [Column("PRO_ESTADO")]
        [NotMapped]
        public string PRO_ESTADO { get; set; }

        [Column("PRO_OBSERVACIONES")]
        [NotMapped]
        public string PRO_OBSERVACIONES { get; set; }

        [Column("LIN_NOMBRE")]
        [NotMapped]
        public string LIN_NOMBRE { get; set; }

        [Column("Ubicacion")]
        [NotMapped]
        public string Ubicacion { get; set; }

        [Column("area")]
        [NotMapped]
        public string Area { get; set; }









        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        //[InverseProperty("Tdo")]
        //public virtual ICollection<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
    }
}
