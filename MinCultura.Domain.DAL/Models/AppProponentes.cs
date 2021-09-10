using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinCultura.Domain.DAL.Models
{
    [Table("APP_PROPONENTES")]
    public partial class AppProponentes
    {
        public AppProponentes()
        {
            AppProyectos = new HashSet<AppProyectos>();
        }

        [Key]
        [Column("PRO_ID", TypeName = "numeric(18, 0)")]
        public decimal ProId { get; set; }
        [Column("PRO_RAZON_SOCIAL")]
        [StringLength(500)]
        public string ProRazonSocial { get; set; }
        [Column("PRO_NIT")]
        [StringLength(20)]
        public string ProNit { get; set; }

        [Column("PRO_PRIMER_NOMBRE_REP_LEGAL")]
        [StringLength(100)]
        public string ProPrimerNombreRepLegal { get; set; }

        [Column("PRO_SEGUNDO_NOMBRE_REP_LEGAL")]
        [StringLength(100)]
        public string ProSegundoNombreRepLegal { get; set; }

        [Column("PRO_PRIMER_APELLIDO_REP_LEGAL")]
        [StringLength(100)]
        public string ProPrimerApellidoRepLegal { get; set; }

        [Column("PRO_SEGUNDO_APELLIDO_REP_LEGAL")]
        [StringLength(100)]
        public string ProSegundoApellidoRepLegal { get; set; }

        [Column("PRO_DOCUMENTO_IDENTIDAD_REPRESENTANTE_LEGAL")]
        [StringLength(20)]
        public string ProDocumentoIdentidadRepresentanteLegal { get; set; }
        [Column("PRO_LUGAR_EXPEDICION_DOCUMENTO_REPRESENTANTE_LEGAL")]
        [StringLength(100)]
        public string ProLugarExpedicionDocumentoRepresentanteLegal { get; set; }
        [Column("PRO_DIRECCION_REPRESENTANTE_LEGAL")]
        [StringLength(100)]
        public string ProDireccionRepresentanteLegal { get; set; }
        [Column("PRO_TELEFONOS_REPRESENTANTE_LEGAL")]
        [StringLength(50)]
        public string ProTelefonosRepresentanteLegal { get; set; }
        [Column("PRO_TELEFONO_CELULAR")]
        [StringLength(50)]
        public string ProTelefonoCelular { get; set; }
        [Column("PRO_FAX_REPRESENTANTE_LEGAL")]
        [StringLength(50)]
        public string ProFaxRepresentanteLegal { get; set; }
        [Column("PRO_CORREO_ELECTRONICO_REPRESENTANTE_LEGAL")]
        [StringLength(100)]
        public string ProCorreoElectronicoRepresentanteLegal { get; set; }
        [Column("PRO_REGIMEN_TRIBUTARIO")]
        [StringLength(1)]
        public string ProRegimenTributario { get; set; }
        [Column("PRO_GRAN_CONTRIBUYENTE")]
        [StringLength(1)]
        public string ProGranContribuyente { get; set; }
        [Column("PRO_TARIFA", TypeName = "numeric(10, 2)")]
        public decimal? ProTarifa { get; set; }
        [Column("PRO_RESPONSABLE_IVA")]
        [StringLength(1)]
        public string ProResponsableIva { get; set; }
        [Column("PRO_TARIFA_ICA")]
        [StringLength(10)]
        public string ProTarifaIca { get; set; }
        [Column("ZON_ID")]
        [StringLength(5)]
        public string ZonId { get; set; }
        [Column("TIP_ID")]
        public int? TipId { get; set; }
        [Column("ZON_ID_EXPEDICION_DOCUMENTO")]
        [StringLength(5)]
        public string ZonIdExpedicionDocumento { get; set; }
        [Column("PRO_BARRIO_COMUNA")]
        [StringLength(500)]
        public string ProBarrioComuna { get; set; }
        [Column("PRO_TIPO_VINCULACION_PERSONA")]
        [StringLength(500)]
        public string ProTipoVinculacionPersona { get; set; }
        [Column("PRO_DIRTRAD")]
        [StringLength(120)]
        public string ProDirtrad { get; set; }
        [Column("PRO_LATITUD")]
        public double? ProLatitud { get; set; }
        [Column("PRO_LONGITUD")]
        public double? ProLongitud { get; set; }
        [Column("PRO_ESTADO_GEO")]
        [StringLength(2)]
        public string ProEstadoGeo { get; set; }
        [Column("PRO_ACTUALIZA_PRIMERA_VEZ")]
        public int? ProActualizaPrimeraVez { get; set; }
        [Column("DET_PROP_ID")]
        public int? DetPropId { get; set; }
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

        [ForeignKey(nameof(TipId))]
        [InverseProperty(nameof(AppTiposEntidades.AppProponentes))]
        public virtual AppTiposEntidades Tip { get; set; }


        [ForeignKey(nameof(ZonId))]
        [InverseProperty(nameof(BasZonasGeograficas.AppProponentes))]
        public virtual BasZonasGeograficas Zon { get; set; }


        [InverseProperty("ProIdProponenteNavigation")]
        public virtual ICollection<AppProyectos> AppProyectos { get; set; }
    }
}