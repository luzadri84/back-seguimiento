using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("ENVIO_CORREOS")]
    public partial class EnvioCorreos
    {

        public EnvioCorreos()
        {
            AdjuntoCorreo = new HashSet<AdjuntoCorreo>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("PRO_ID")]
        public int proId { get; set; }

        [Required]
        [Column("ASUNTO")]
        [StringLength(500)]
        public string Asunto { get; set; }

        [Required]
        [Column("CUERPO")]
        public string Cuerpo { get; set; }


        [Required]
        [Column("REMITENTES")]
        public string Remitentes { get; set; }

        [Required]
        [Column("ENVIADO")]
        public bool Enviado { get; set; }

        [Required]
        [Column("INTENTO")]
        public int Intento { get; set; }

        [Column("FECHA_ENVIO", TypeName = "datetime")]
        public DateTime? FechaEnvio { get; set; }

        [Required]
        [Column("FECHA_CREO", TypeName = "datetime")]
        public DateTime FechaCreo { get; set; }

        [Column("OBSERVACIONES")]
        [StringLength(500)]
        public string Observaciones { get; set; }

        [InverseProperty("EnvioCorreos")]
        public virtual ICollection<AdjuntoCorreo> AdjuntoCorreo { get; set; }
    }
}
