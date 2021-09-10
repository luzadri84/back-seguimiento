using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MinCultura.Domain.DAL.Models
{

    [Table("ADJUNTO_CORREOS")]
    public class AdjuntoCorreo
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_ENVIO")]
        [Required]
        public int IdEnvio { get; set; }

        [Required]
        [Column("RUTA_ADJUNTO")]
        [StringLength(500)]
        public string RutaAdjunto { get; set; }

        [Required]
        [Column("NOMBRE_ADJUNTO")]
        [StringLength(500)]
        public string NombreAdjunto { get; set; }

        [Required]
        [Column("FECHA_CREO", TypeName = "datetime")]
        public DateTime FechaCreo { get; set; }

        [ForeignKey(nameof(IdEnvio))]
        [InverseProperty("AdjuntoCorreo")]
        public virtual EnvioCorreos EnvioCorreos { get; set; }
    }
}
