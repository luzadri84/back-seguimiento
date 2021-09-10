using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.DAL.Models
{
    [Table("PREGUNTA_USUARIO", Schema = "Seguridad")]
    public partial class PreguntaUsuario
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }
        [Column("CUENTAUSUARIOID")]
        public int Cuentausuarioid { get; set; }
        [Column("IDPREGUNTA")]
        public int Idpregunta { get; set; }
        [Required]
        [Column("RESPUESTA")]
        [StringLength(500)]
        public string Respuesta { get; set; }
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

        [ForeignKey(nameof(Cuentausuarioid))]
        [InverseProperty("PreguntaUsuario")]
        public virtual Cuentausuario Cuentausuario { get; set; }
        [ForeignKey(nameof(Idpregunta))]
        [InverseProperty(nameof(PreguntaSeguridad.PreguntaUsuario))]
        public virtual PreguntaSeguridad IdpreguntaNavigation { get; set; }
    }
}
