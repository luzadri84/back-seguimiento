using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("PREGUNTA_SEGURIDAD", Schema = "Seguridad")]
    public partial class PreguntaSeguridad
    {
        public PreguntaSeguridad()
        {
            PreguntaUsuario = new HashSet<PreguntaUsuario>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("PREGUNTA")]
        [StringLength(500)]
        public string Pregunta { get; set; }
        [Column("ESTADO")]
        public bool Estado { get; set; }
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

        [InverseProperty("IdpreguntaNavigation")]
        public virtual ICollection<PreguntaUsuario> PreguntaUsuario { get; set; }
    }
}
