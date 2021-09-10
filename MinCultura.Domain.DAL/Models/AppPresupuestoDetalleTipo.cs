using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_PRESUPUESTO_DETALLE_TIPO")]
    public partial class AppPresupuestoDetalleTipo
    {
        public AppPresupuestoDetalleTipo()
        {
            //AppPresupuestoDetalle = new HashSet<AppPresupuestoDetalle>();
        }

        [Key]
        [Column("APT_ID", TypeName = "numeric(18, 0)")]
        public decimal AptId { get; set; }

        [Column("APT_DESCRIPCION")]
        [StringLength(500)]
        public string AptDescripcion { get; set; }

        [Column("APT_ORDEN", TypeName = "numeric(2, 0)")]
        public decimal? AptOrden { get; set; }

        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal? VIG_ID { get; set; }

        [Column("ATT_ID")]
        //[StringLength(1000)]
        public int ATT_ID { get; set; }

        [Column("TCP_ID")]
        public int TCP_ID { get; set; }


        //[Required]
        //[Column("USU_CREO")]
        //[StringLength(100)]
        //public string UsuCreo { get; set; }
        //[Column("USU_MODIFICO")]
        //[StringLength(100)]
        //public string UsuModifico { get; set; }
        //[Column("FEC_CREO", TypeName = "datetime")]
        //public DateTime FecCreo { get; set; }
        //[Column("FEC_MODIFICO", TypeName = "datetime")]
        //public DateTime? FecModifico { get; set; }

        [InverseProperty("Apt")]
        public virtual ICollection<AppPresupuestoDetalle> AppPresupuestoDetalle { get; set; }
    }
}
