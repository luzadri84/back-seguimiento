using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_VIGENCIAS")]
    public partial class AppVigencias
    {
        public AppVigencias()
        {
            AppAreas = new HashSet<AppAreas>();
            AppCausalesRechazo = new HashSet<AppCausalesRechazo>();
            AppRequisitos = new HashSet<AppRequisitos>();
            AppTipoEntidadUsuario = new HashSet<AppTipoEntidadUsuario>();
            AppTiposPuntaje = new HashSet<AppTiposPuntaje>();
            BasTiposProyectos = new HashSet<BasTiposProyectos>();
        }

        [Key]
        [Column("VIG_ID", TypeName = "numeric(18, 0)")]
        public decimal VigId { get; set; }
        [Required]
        [Column("VIG_NOMBRE")]
        [StringLength(100)]
        public string VigNombre { get; set; }
        [Column("VIG_FECHA_INICIO", TypeName = "datetime")]
        public DateTime VigFechaInicio { get; set; }
        [Column("VIG_FECHA_FINAL", TypeName = "datetime")]
        public DateTime VigFechaFinal { get; set; }
        [Required]
        [Column("VIG_ESTADO")]
        [StringLength(1)]
        public string VigEstado { get; set; }
        [Column("VIG_PLAZO_DOCUMENTACION")]
        public int? VigPlazoDocumentacion { get; set; }
        [Column("VIG_DIAS_EXPIRACION_PROYECTO")]
        public int? VigDiasExpiracionProyecto { get; set; }
        [Column("VIG_CONSECUTIVO")]
        public int? VigConsecutivo { get; set; }
        [Column("VIG_CONSECUTIVO_NAC")]
        public int VigConsecutivoNac { get; set; }
        [Column("VIG_VALOR_MAXIMO")]
        public int? VigValorMaximo { get; set; }
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

        [InverseProperty("Vig")]
        public virtual ICollection<AppAreas> AppAreas { get; set; }
        [InverseProperty("Vig")]
        public virtual ICollection<AppCausalesRechazo> AppCausalesRechazo { get; set; }
        [InverseProperty("Vig")]
        public virtual ICollection<AppRequisitos> AppRequisitos { get; set; }
        [InverseProperty("IdVigenciaNavigation")]
        public virtual ICollection<AppTipoEntidadUsuario> AppTipoEntidadUsuario { get; set; }
        [InverseProperty("Vig")]
        public virtual ICollection<AppTiposPuntaje> AppTiposPuntaje { get; set; }
        [InverseProperty("Vig")]
        public virtual ICollection<BasTiposProyectos> BasTiposProyectos { get; set; }
    }
}
