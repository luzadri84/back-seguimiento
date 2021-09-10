using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_BENEFICIARIOS")]
    public partial class AppBeneficiarios
    {
        [Key]
        [Column("BEN_ID", TypeName = "numeric(18, 0)")]
        public decimal BenId { get; set; }
        [Column("BEN_PERSONAS_ASISTENTES", TypeName = "numeric(18, 0)")]
        public decimal? BenPersonasAsistentes { get; set; }
        [Column("BEN_NUMERO_ARTISTAS_NACIONALES", TypeName = "numeric(18, 0)")]
        public decimal? BenNumeroArtistasNacionales { get; set; }
        [Column("BEE_TOTAL_BENEFICIADOS", TypeName = "numeric(18, 0)")]
        public decimal? BeeTotalBeneficiados { get; set; }
        [Column("BEN_NUMERO_ARTISTAS_INTERNACIONALES", TypeName = "numeric(18, 0)")]
        public decimal? BenNumeroArtistasInternacionales { get; set; }
        [Column("PRO_ID", TypeName = "decimal(18, 0)")]
        public decimal? ProId { get; set; }
        [Column("BEN_PERSONAS_LOGISTICA", TypeName = "numeric(18, 0)")]
        public decimal? BenPersonasLogistica { get; set; }
        [Column("BEN_OTRAS_PERSONAS_BENEFICIADAS_DESCRIPCION")]
        public string BenOtrasPersonasBeneficiadasDescripcion { get; set; }
        
        [Column("BEN_CARACTERISTICAS_POBLACION")]
        public string BenCaracteristicasPoblacion { get; set; }
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

        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(AppProyectos.AppBeneficiarios))]
        public virtual AppProyectos Pro { get; set; }
    }
}
