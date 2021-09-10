using Microsoft.EntityFrameworkCore;
using MinCultura.Domain.Common;
using MinCultura.Domain.DAL.Models;

namespace MinCultura.Domain.DAL.Context
{
    public partial class ConcertacionContext : DbContext
    {
        public ConcertacionContext()
        {
        }

        public ConcertacionContext(DbContextOptions<ConcertacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppAreas> AppAreas { get; set; }
        public virtual DbSet<AppBeneficiarios> AppBeneficiarios { get; set; }
        public virtual DbSet<AppCausalesRechazo> AppCausalesRechazo { get; set; }
        public virtual DbSet<AppComponentes> AppComponentes { get; set; }
        public virtual DbSet<AppContratacion> AppContratacion { get; set; }
        public virtual DbSet<AppDetalleTiposEntidades> AppDetalleTiposEntidades { get; set; }
        public virtual DbSet<AppDocumentosTipoEntidades> AppDocumentosTipoEntidades { get; set; }
        public virtual DbSet<AppEstadoContratacion> AppEstadoContratacion { get; set; }
        public virtual DbSet<AppEvaluacionRequisitos> AppEvaluacionRequisitos { get; set; }
        public virtual DbSet<AppIndicadores> AppIndicadores { get; set; }
        public virtual DbSet<AppIndicadoresLinea> AppIndicadoresLinea { get; set; }
        public virtual DbSet<AppLineas> AppLineas { get; set; }
        public virtual DbSet<AppTemas> AppTemas { get; set; }
        public virtual DbSet<AppTemasProyectos> AppTemasProyectos { get; set; }
        public virtual DbSet<AppPresupuestoDetalle> AppPresupuestoDetalle { get; set; }
        public virtual DbSet<AppPresupuestoDetalleTipo> AppPresupuestoDetalleTipo { get; set; }
        public virtual DbSet<AppProponentes> AppProponentes { get; set; }
        public virtual DbSet<AppProyectos> AppProyectos { get; set; }
        public virtual DbSet<AppCronograma> AppCronograma { get; set; }
        public virtual DbSet<AppActividadesObligatorias> AppActividadesObligatorias { get; set; }
        public virtual DbSet<AppProyectoActividadesObligatorias> AppProyectoActividadesObligatorias { get; set; }
        public virtual DbSet<AppValoresIndicadorLineaCategoriaMunicipio> AppValoresIndicadorLineaCategoriaMunicipio { get; set; }
        public virtual DbSet<AppIndicadorLineaCategoriaMunicipio> AppIndicadorLineaCategoriaMunicipio { get; set; }
        public virtual DbSet<AppPuntajeProyecto> AppPuntajeProyecto { get; set; }
        public virtual DbSet<AppRangos> AppRangos { get; set; }
        public virtual DbSet<AppRegistroRechazados> AppRegistroRechazados { get; set; }
        public virtual DbSet<AppRequisitos> AppRequisitos { get; set; }
        public virtual DbSet<AppTipoDocumentos> AppTipoDocumentos { get; set; }
        public virtual DbSet<AppTipoDocumentosValores> AppTipoDocumentosValores { get; set; }
        public virtual DbSet<AppTipoEntidadUsuario> AppTipoEntidadUsuario { get; set; }
        public virtual DbSet<AppTipoProyectoProponente> AppTipoProyectoProponente { get; set; }
        public virtual DbSet<AppTiposEntidades> AppTiposEntidades { get; set; }
        public virtual DbSet<AppTiposPuntaje> AppTiposPuntaje { get; set; }
        public virtual DbSet<AppUsuariosImpresion> AppUsuariosImpresion { get; set; }
        public virtual DbSet<AppValoresIndicador> AppValoresIndicador { get; set; }
        public virtual DbSet<AppVariables> AppVariables { get; set; }
        public virtual DbSet<AppVigencias> AppVigencias { get; set; }
        public virtual DbSet<BasDependencias> BasDependencias { get; set; }
        public virtual DbSet<BasEntidadesFinancieras> BasEntidadesFinancieras { get; set; }
        public virtual DbSet<BasTiposProyectos> BasTiposProyectos { get; set; }
        public virtual DbSet<BasZonasGeograficas> BasZonasGeograficas { get; set; }
        public virtual DbSet<Cuentausuario> Cuentausuario { get; set; }
        public virtual DbSet<Logacciones> Logacciones { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilesCuentausuario> PerfilesCuentausuario { get; set; }
        public virtual DbSet<PlantillaCorreos> PlantillaCorreos { get; set; }
        public virtual DbSet<PreguntaSeguridad> PreguntaSeguridad { get; set; }
        public virtual DbSet<PreguntaUsuario> PreguntaUsuario { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<ServiciosPerfil> ServiciosPerfil { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<EnvioCorreos> EnvioCorreos { get; set; }
        public virtual DbSet<AdjuntoCorreo> AdjuntoCorreo { get; set; }
        public virtual DbSet<Trayectoria> Trayectoria { get; set; }
        public virtual DbSet<TipoTrayectoria> TipoTrayectoria { get; set; }
        public virtual DbSet<TrayectoriaProyecto> TrayectoriaProyecto { get; set; }
        public virtual DbSet<AppPresupuestoDetalleTipoTitulos> AppPresupuestoDetalleTipoTitulos { get; set; }
        public virtual DbSet<AppRadicadoProyectos> AppRadicadoProyectos { get; set; }
        public virtual DbSet<PresupuestoParametrizacionLineasTope> PresupuestoParametrizacionLineasTope { get; set; }

        public virtual DbSet<AdmConfiguracion> AdmConfiguracion { get; set; }
        public virtual DbSet<AdmPerfiles> AdmPerfiles { get; set; }
        public virtual DbSet<AdmPerfilesUsuarios> AdmPerfilesUsuarios { get; set; }
        public virtual DbSet<AdmUsuarios> AdmUsuarios { get; set; }

        public virtual DbSet<ConEstados> ConEstados { get; set; }

        public virtual DbSet<ConZonas> ConZonas { get; set; }

        public virtual DbSet<ConActividades> ConActividades { get; set; }

        public virtual DbSet<ConSeguimientos> ConSeguimientos { get; set; }


        public virtual DbSet<Resultado> Resultados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var env = new EnvManager();
                optionsBuilder.UseSqlServer(env.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppAreas>(entity =>
            {
                entity.Property(e => e.AreId)
                    .HasComment("Identificador único del área")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AreNombre)
                    .IsUnicode(false)
                    .HasComment("Nombre del área");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.VigId).HasComment("Identificador de la vigencia.");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppAreas)
                    .HasForeignKey(d => d.VigId)
                    .HasConstraintName("FK_APP_VIGENCIAS_APP_AREAS");
            });

            modelBuilder.Entity<AppRadicadoProyectos>(entity =>
            {
                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppRadicadoProyectos)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_RADICADO_PROYECTOS_APP_PROYECTOS");
            });


            modelBuilder.Entity<AppIndicadorLineaCategoriaMunicipio>(entity =>
            {
                entity.HasKey(e => e.IlcmId)
                    .HasName("PK_INDICADOR_LINEA_MUNICIPIOS");

                entity.ToTable("APP_INDICADOR_LINEA_CATEGORIA_MUNICIPIO");

                entity.Property(e => e.IlcmId)
                    .HasColumnName("ILCM_ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdZonCategoria)
                    .HasColumnName("ID_ZON_CATEGORIA")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IlmOrder)
                    .HasColumnName("ILM_ORDER")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IndId)
                    .HasColumnName("IND_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.LinId)
                    .HasColumnName("LIN_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ind)
                    .WithMany(p => p.AppIndicadorLineaCategoriaMunicipio)
                    .HasForeignKey(d => d.IndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INDICADOR_LINEA_MUNICIPIOS_APP_INDICADORES");

                entity.HasOne(d => d.Lin)
                    .WithMany(p => p.AppIndicadorLineaCategoriaMunicipio)
                    .HasForeignKey(d => d.LinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INDICADOR_LINEA_MUNICIPIOS_APP_LINEAS");
            });

            modelBuilder.Entity<AppValoresIndicadorLineaCategoriaMunicipio>(entity =>
            {
                entity.HasKey(e => e.VilcmId)
                    .HasName("PK_VALOR_INDICADOR_LINEAS_MUNICIPIOS");

                entity.ToTable("APP_VALORES_INDICADOR_LINEA_CATEGORIA_MUNICIPIO");

                entity.Property(e => e.VilcmId)
                    .HasColumnName("VILCM_ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IlcmId)
                    .HasColumnName("ILCM_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ValValor)
                    .HasColumnName("VAL_VALOR")
                    .HasColumnType("decimal(33, 15)");

                entity.Property(e => e.ValValorTexto)
                    .HasColumnName("VAL_VALOR_TEXTO")
                    .IsUnicode(false);

                entity.HasOne(d => d.Ilcm)
                    .WithMany(p => p.AppValoresIndicadorLineaCategoriaMunicipio)
                    .HasForeignKey(d => d.IlcmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VALOR_INDICADOR_LINEAS_MUNICIPIOS_INDICADOR_LINEA_MUNICIPIOS");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppValoresIndicadorLineaCategoriaMunicipio)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VALOR_INDICADOR_LINEAS_MUNICIPIOS_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppBeneficiarios>(entity =>
            {
                entity.Property(e => e.BenId).ValueGeneratedOnAdd();

                entity.Property(e => e.BenPersonasAsistentes).IsUnicode(false);

                entity.Property(e => e.BenNumeroArtistasInternacionales).IsUnicode(false);

                entity.Property(e => e.BeeTotalBeneficiados).IsUnicode(false);

                entity.Property(e => e.BenNumeroArtistasInternacionales).IsUnicode(false);

                entity.Property(e => e.ProId).IsUnicode(false);

                entity.Property(e => e.BenPersonasLogistica).IsUnicode(false);

                entity.Property(e => e.BenOtrasPersonasBeneficiadasDescripcion).IsUnicode(false);

                entity.Property(e => e.BenCaracteristicasPoblacion).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.FecCreo).IsUnicode(false);
                entity.Property(e => e.FecModifico).IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppBeneficiarios)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_BENEFICIARIOS_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppCausalesRechazo>(entity =>
            {
                entity.Property(e => e.CauId).ValueGeneratedOnAdd();

                entity.Property(e => e.CauDescripcion).IsUnicode(false);

                entity.Property(e => e.CauNombre)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Nombre de la causal de rexhazo");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppCausalesRechazo)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_CAUSALES_RECHAZO_APP_VIGENCIAS");
            });

            modelBuilder.Entity<AppComponentes>(entity =>
            {
                entity.Property(e => e.ComId).ValueGeneratedOnAdd();

                entity.Property(e => e.ComTrayectoriaSeleccion).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppComponentes)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_COMPONENTES_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppContratacion>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ConAbogado).IsUnicode(false);

                entity.Property(e => e.ConActa).IsUnicode(false);

                entity.Property(e => e.ConAnexos)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConCdp).IsUnicode(false);

                entity.Property(e => e.ConContratando)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConConveniofirmado)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConCorreeosupervisor)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConCorreofinalizacion)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConCrp).IsUnicode(false);

                entity.Property(e => e.ConEvaluacion)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConFechaacta)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConFechacdp)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConFormaPago).IsUnicode(false);

                entity.Property(e => e.ConFormatoA)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConFormatoB)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConGarantiaCumpOk)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConGarantiaManejoOk)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConGarantiaSalarioOk)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConLinksecop).IsUnicode(false);

                entity.Property(e => e.ConNumProcesoSecop).IsUnicode(false);

                entity.Property(e => e.ConRegistropresup).IsUnicode(false);

                entity.Property(e => e.ConRegistropresupSN)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConUsuario).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.AppContratacion)
                    .HasForeignKey(d => d.DepId)
                    .HasConstraintName("FK_APP_CONTRATACION_BAS_DEPENDENCIAS");

                entity.HasOne(d => d.Esc)
                    .WithMany(p => p.AppContratacion)
                    .HasForeignKey(d => d.EscId)
                    .HasConstraintName("FK_APP_CONTRATACION_APP_ESTADO_CONTRATACION");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppContratacion)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_CONTRATACION_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppDetalleTiposEntidades>(entity =>
            {
                entity.Property(e => e.DetId).ValueGeneratedNever();

                entity.Property(e => e.DetNombre).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.AppDetalleTiposEntidades)
                    .HasForeignKey(d => d.TipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_DETALLE_TIPOS_ENTIDADES_APP_TIPOS_ENTIDADES");
            });

            modelBuilder.Entity<AppDocumentosTipoEntidades>(entity =>
            {
                entity.HasKey(e => new { e.TdoId, e.TipId });

                entity.Property(e => e.TdoNs).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Tdo)
                    .WithMany(p => p.AppDocumentosTipoEntidades)
                    .HasForeignKey(d => d.TdoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_DOCUMENTOS_TIPO_ENTIDADES_APP_TIPO_DOCUMENTOS");

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.AppDocumentosTipoEntidades)
                    .HasForeignKey(d => d.TipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_DOCUMENTOS_TIPO_ENTIDADES_APP_TIPOS_ENTIDADES");
            });

            modelBuilder.Entity<AppEstadoContratacion>(entity =>
            {
                entity.Property(e => e.EscNombre).IsUnicode(false);
            });

            modelBuilder.Entity<AppEvaluacionRequisitos>(entity =>
            {
                entity.HasKey(e => new { e.ProId, e.ReqId });

                entity.Property(e => e.ProId).HasComment("Identificador del proyecto");

                entity.Property(e => e.ReqId).HasComment("Identificador del requerimiento");

                entity.Property(e => e.EvaObservacion)
                    .IsUnicode(false)
                    .HasComment("Observación del por que de la calificación o el valor asignado al requisito");

                entity.Property(e => e.PunSolicitud)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PunValor)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Indica si cumple con el requisito (S) o No cumple (N).");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppEvaluacionRequisitos)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_EVALUACION_REQUISITOS_APP_PROYECTOS");

                entity.HasOne(d => d.Req)
                    .WithMany(p => p.AppEvaluacionRequisitos)
                    .HasForeignKey(d => d.ReqId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_REQUISITOS_APP_EVALUACION_REQUISITOS");
            });

            modelBuilder.Entity<AppIndicadores>(entity =>
            {
                entity.HasComment("Es es la tabla de variables");

                entity.Property(e => e.IndId).ValueGeneratedOnAdd();

                entity.Property(e => e.IndDescripcion).IsUnicode(false);

                entity.Property(e => e.IndFormula).IsUnicode(false);

                entity.Property(e => e.IndNombre).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
            });

            modelBuilder.Entity<AppIndicadoresLinea>(entity =>
            {
                entity.HasKey(e => new { e.IndId, e.LinId });

                entity.HasComment("Esta tabla es Variables por Línea");

                entity.Property(e => e.IndId).HasComment("Identificador único del indicador");

                entity.Property(e => e.LinId).HasComment("Identificador de la línea");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Ind)
                    .WithMany(p => p.AppIndicadoresLinea)
                    .HasForeignKey(d => d.IndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_INDICADORES_LINEA_APP_INDICADORES");

            });

            modelBuilder.Entity<AppLineas>(entity =>
            {
                entity.Property(e => e.LinId).ValueGeneratedOnAdd();

                entity.Property(e => e.LinDescripcion).IsUnicode(false);

                entity.Property(e => e.LinNombre).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
            });

            modelBuilder.Entity<AppPresupuestoDetalle>(entity =>
            {
                entity.Property(e => e.PdeId).ValueGeneratedOnAdd();

                entity.Property(e => e.PdeValorTotal).IsUnicode(false);

                entity.Property(e => e.PdeRecursosMunicipio).IsUnicode(false);

                entity.Property(e => e.PdeRecursosDepartmento).IsUnicode(false);

                entity.Property(e => e.PdeRecursosMinisterio).IsUnicode(false);
                entity.Property(e => e.PdeIngresosPropios).IsUnicode(false);

                entity.Property(e => e.PdeOtrosRecursos).IsUnicode(false);
                entity.Property(e => e.ProId).IsUnicode(false);

                entity.Property(e => e.AptId).IsUnicode(false);
                entity.Property(e => e.PdeDetalleOtrosRecursos).IsUnicode(false);
                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
                entity.Property(e => e.FecCreo).IsUnicode(false);
                entity.Property(e => e.FecModifico).IsUnicode(false);
            });

            modelBuilder.Entity<AppPresupuestoDetalleTipo>(entity =>
            {
                entity.Property(e => e.AptId).ValueGeneratedOnAdd();

                entity.Property(e => e.AptDescripcion).IsUnicode(false);
                entity.Property(e => e.AptOrden).IsUnicode(false);
                entity.Property(e => e.VIG_ID).IsUnicode(false);
                entity.Property(e => e.ATT_ID).IsUnicode(false);
                //entity.Property(e => e.UsuCreo).IsUnicode(false);

                //entity.Property(e => e.UsuModifico).IsUnicode(false);
            });


            modelBuilder.Entity<AppProyectoActividadesObligatorias>(entity =>
            {
                entity.HasOne(d => d.ActObl)
                    .WithMany(p => p.AppProyectosActObligatorias)
                    .HasForeignKey(d => d.ActId)
                    .HasConstraintName("FK_APP_PROYECTO_ACTIVIDADES_OBLIGATORIAS_APP_ACTIVIDADES_OBLIGATORIAS");
            });

            modelBuilder.Entity<AppProponentes>(entity =>
            {
                entity.Property(e => e.ProId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProBarrioComuna).IsUnicode(false);

                entity.Property(e => e.ProCorreoElectronicoRepresentanteLegal).IsUnicode(false);

                entity.Property(e => e.ProDireccionRepresentanteLegal).IsUnicode(false);

                entity.Property(e => e.ProDirtrad).IsUnicode(false);

                entity.Property(e => e.ProDocumentoIdentidadRepresentanteLegal).IsUnicode(false);

                entity.Property(e => e.ProEstadoGeo).IsUnicode(false);

                entity.Property(e => e.ProFaxRepresentanteLegal).IsUnicode(false);

                entity.Property(e => e.ProGranContribuyente)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProLugarExpedicionDocumentoRepresentanteLegal).IsUnicode(false);

                entity.Property(e => e.ProNit).IsUnicode(false);

                entity.Property(e => e.ProRazonSocial).IsUnicode(false);

                entity.Property(e => e.ProRegimenTributario)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProResponsableIva)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProTelefonoCelular).IsUnicode(false);

                entity.Property(e => e.ProTelefonosRepresentanteLegal).IsUnicode(false);

                entity.Property(e => e.ProTipoVinculacionPersona).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.ZonId).IsUnicode(false);

                entity.Property(e => e.ZonIdExpedicionDocumento).IsUnicode(false);

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.AppProponentes)
                    .HasForeignKey(d => d.TipId)
                    .HasConstraintName("FK_APP_PROPONENTES_APP_TIPOS_ENTIDADES");

                entity.HasOne(d => d.Zon)
                    .WithMany(p => p.AppProponentes)
                    .HasForeignKey(d => d.ZonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_PROPONENTES_BAS_ZONAS_GEOGRAFICAS");
            });

            modelBuilder.Entity<AppProyectos>(entity =>
            {
                entity.Property(e => e.ProId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProActaAjuste)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProActaComite)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProActaInicial)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProCiudadEntidadFinanciera).IsUnicode(false);

                entity.Property(e => e.ProCorreoPersonaEncargada).IsUnicode(false);

                entity.Property(e => e.ProEstado)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProEstadoNuevo)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProFirmado)
                    .IsUnicode(false)
                    .IsFixedLength();


                entity.Property(e => e.ProImagenOrganigrama).IsUnicode(false);

                entity.Property(e => e.ProImagenPlano).IsUnicode(false);

                entity.Property(e => e.ProIncentivo).IsUnicode(false);

                entity.Property(e => e.ProNombre).IsUnicode(false);

                entity.Property(e => e.ProNumeroCuenta).IsUnicode(false);

                entity.Property(e => e.ProNumeroRadicacion).IsUnicode(false);

                entity.Property(e => e.ProObjeto).IsUnicode(false);

                entity.Property(e => e.ProObservaciones).IsUnicode(false);

                entity.Property(e => e.ProObservacionesEvaluacion).IsUnicode(false);

                entity.Property(e => e.ProOtraArea).IsUnicode(false);

                entity.Property(e => e.ProPeriodicidadCronograma)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProPersonaEncargadaProyecto).IsUnicode(false);

                entity.Property(e => e.ProTelefonosPersonaEncargadaProyecto).IsUnicode(false);
                

                entity.Property(e => e.ProTipoCuenta)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.ZonId).IsUnicode(false);

                entity.Property(e => e.ZonIdEntidadBancaria).IsUnicode(false);

                entity.Property(e => e.ProConvenio).IsUnicode(false);
                entity.Property(e => e.ProFechaLegalizacion).IsUnicode(false);
                entity.Property(e => e.ProCelularPersonaEncargada).IsUnicode(false);
                entity.Property(e => e.ProFechaPuntualInicial).IsUnicode(false);
                entity.Property(e => e.ProFechaPuntualFinal).IsUnicode(false);



                entity.Property(e => e.ProUsuarioAsignado).IsUnicode(false);
                entity.Property(e => e.ZonaId).IsUnicode(false);
                entity.Property(e => e.ProFechaEntregadoSupervisor).IsUnicode(false);
                entity.Property(e => e.ProFechaProrroga).IsUnicode(false);
                entity.Property(e => e.ProEstadoSeguimiento).IsUnicode(false);
                entity.Property(e => e.ProFechaEstado).IsUnicode(false);
                entity.Property(e => e.ProFechaRadicacionSeguimiento).IsUnicode(false);
                entity.Property(e => e.ProCuentasPagar).IsUnicode(false);
                entity.Property(e => e.ProEstadoObservaciones).IsUnicode(false);



                entity.HasOne(d => d.Ent)
                    .WithMany(p => p.AppProyectos)
                    .HasForeignKey(d => d.EntId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_PROYECTOS_BAS_ENTIDADES_FINANCIERAS");

                entity.HasOne(d => d.ProIdProponenteNavigation)
                    .WithMany(p => p.AppProyectos)
                    .HasForeignKey(d => d.ProIdProponente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_PROYECTOS_APP_PROPONENTES");
            });

            modelBuilder.Entity<AppCronograma>(entity =>
            {
                entity.HasKey(e => e.CprId)
                    .HasName("PK_APP_CRONOGRAMA_PROYECTOS");

                entity.Property(e => e.CprId).ValueGeneratedOnAdd();

                entity.Property(e => e.CprActividad).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppCronograma)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_CRONOGRAMA_PROYECTOS_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppPuntajeProyecto>(entity =>
            {
                entity.HasKey(e => new { e.RanId, e.ProId });

                entity.Property(e => e.ProId).HasComment("Identificador del proyecto");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Ran)
                    .WithMany(p => p.AppPuntajeProyecto)
                    .HasForeignKey(d => d.RanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_RANGOS_APP_PUNTAJE_PROYECTO");
            });

            modelBuilder.Entity<AppRangos>(entity =>
            {
                entity.Property(e => e.RanId).ValueGeneratedOnAdd();

                entity.Property(e => e.RanDescripcion)
                    .IsUnicode(false)
                    .HasComment("Descripción del rango. Por ejemplo,  de 6 meses hasta 3 años");

                entity.Property(e => e.RanPuntaje).HasComment("Valor de puntaje asignado para cuando se seleccione este rango");

                entity.Property(e => e.RanPuntajeAbierto)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Determina si la variable permite un valor de puntaje abierto (S) y no un rango (N)");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.VarId).HasComment("Identificador de la variable.");

                entity.HasOne(d => d.Var)
                    .WithMany(p => p.AppRangos)
                    .HasForeignKey(d => d.VarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VARIABLES_APP_RANGOS");
            });

            modelBuilder.Entity<AppRegistroRechazados>(entity =>
            {
                entity.Property(e => e.ReqId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProObservaciones).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppRegistroRechazados)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_REGISTRO_RECHAZADOS_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppRequisitos>(entity =>
            {
                entity.Property(e => e.ReqId)
                    .HasComment("Identificador del requerimiento")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ReqCausalRechazo)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.ReqNombre)
                    .IsUnicode(false)
                    .HasComment("Nombre o descripción del requerimiento");

                entity.Property(e => e.ReqOrden).HasDefaultValueSql("((0))");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.VigId).HasComment("Identificador de la vigencia.");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppRequisitos)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VIGENCIAS_APP_REQUISITOS");
            });

            modelBuilder.Entity<AppTipoDocumentos>(entity =>
            {
                entity.Property(e => e.TdoId).ValueGeneratedOnAdd();

                entity.Property(e => e.TdoNombre).IsUnicode(false);

                entity.Property(e => e.TdoObservacion).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
            });

            modelBuilder.Entity<AppTipoDocumentosValores>(entity =>
            {
                entity.Property(e => e.TdvId).ValueGeneratedOnAdd();

                entity.Property(e => e.TdvNombre).IsUnicode(false);

                entity.Property(e => e.TdvRutaAdjunto).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppTipoDocumentosValores)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_TIPO_DOCUMENTOS_VALORES_APP_PROYECTOS");

                entity.HasOne(d => d.Tdo)
                    .WithMany(p => p.AppTipoDocumentosValores)
                    .HasForeignKey(d => d.TdoId)
                    .HasConstraintName("FK_APP_TIPO_DOCUMENTOS_VALORES_APP_TIPO_DOCUMENTOS");
            });

            modelBuilder.Entity<AppTipoEntidadUsuario>(entity =>
            {
                entity.HasKey(e => new { e.Nit, e.IdVigencia })
                    .HasName("PK__APP_TIPO__862DD7D2B49D4EFA");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.IdDetalleTipoEntidadNavigation)
                    .WithMany(p => p.AppTipoEntidadUsuario)
                    .HasForeignKey(d => d.IdDetalleTipoEntidad)
                    .HasConstraintName("FK_APP_DETALLE_TIPOS_ENTIDADES_APP_TIPO_ENTIDAD_USUARIO");

                entity.HasOne(d => d.IdTipoEntidadNavigation)
                    .WithMany(p => p.AppTipoEntidadUsuario)
                    .HasForeignKey(d => d.IdTipoEntidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_TIPOS_ENTIDADES_APP_TIPO_ENTIDAD_USUARIO");

                entity.HasOne(d => d.IdVigenciaNavigation)
                    .WithMany(p => p.AppTipoEntidadUsuario)
                    .HasForeignKey(d => d.IdVigencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VIGENCIAS_APP_TIPO_ENTIDAD_USUARIO");
            });

            modelBuilder.Entity<AppTipoProyectoProponente>(entity =>
            {
                entity.Property(e => e.TppNit).IsFixedLength();

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
            });

            modelBuilder.Entity<AppTiposEntidades>(entity =>
            {
                entity.Property(e => e.TipNombre).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
            });

            modelBuilder.Entity<AppTiposPuntaje>(entity =>
            {
                entity.Property(e => e.PunId)
                    .HasComment("Identificador único para el tipo de puntaje")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PunDescripcion).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.VigId).HasComment("Identificador de la vigencia.");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppTiposPuntaje)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VIGENCIAS_APP_PUNTAJES");
            });


            modelBuilder.Entity<AdjuntoCorreo>(entity =>
            {
                entity.HasOne(d => d.EnvioCorreos)
                    .WithMany(p => p.AdjuntoCorreo)
                    .HasForeignKey(d => d.IdEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADJUNTO_CORREOS_ENVIO_CORREOS");
            });

            modelBuilder.Entity<AppUsuariosImpresion>(entity =>
            {
                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Cuentausuario)
                    .WithMany(p => p.AppUsuariosImpresion)
                    .HasForeignKey(d => d.Cuentausuarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_USUARIOS_IMPRESION_CUENTAUSUARIO");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppUsuariosImpresion)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_USUARIOS_IMPRESION_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppValoresIndicador>(entity =>
            {

                entity.HasComment("Esta tabla son los valores de variable por proyecto");

                entity.Property(e => e.ViId).ValueGeneratedOnAdd();

                entity.Property(e => e.ProId).HasComment("Identificador del proyecto");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.ValValor).HasComment("Valor del indicador.");

                entity.Property(e => e.ValValorTexto).IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppValoresIndicador)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VALORES_INDICADOR_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppVariables>(entity =>
            {
                entity.HasComment("Esta tabla correspond a los criterios de evaluación");

                entity.Property(e => e.VarId)
                    .HasComment("Identificador de la variable.")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PunId).HasComment("Identificador único para el tipo de puntaje");

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.VarDescripcion)
                    .IsUnicode(false)
                    .HasComment("Descripción de la variable");

                entity.Property(e => e.VarFormulado)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Indica si es una variable formulada");

                entity.Property(e => e.VarOperador)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VarOperando1).HasComment("Formula para calcular el valor de la variable");

                entity.HasOne(d => d.Lin)
                    .WithMany(p => p.AppVariables)
                    .HasForeignKey(d => d.LinId)
                    .HasConstraintName("FK_APP_VARIABLES_APP_LINEAS");

                entity.HasOne(d => d.Pun)
                    .WithMany(p => p.AppVariables)
                    .HasForeignKey(d => d.PunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_TIPOS_PUNTAJE_APP_VARIABLES");
            });

            modelBuilder.Entity<AppVigencias>(entity =>
            {
                entity.Property(e => e.VigId)
                    .HasComment("Identificador de la vigencia.")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.VigConsecutivo).HasDefaultValueSql("((0))");

                entity.Property(e => e.VigDiasExpiracionProyecto)
                    .HasDefaultValueSql("((0))")
                    .HasComment("Numero de dias");

                entity.Property(e => e.VigEstado)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')")
                    .HasComment("Estado de la Vigencia. Activa (A) o Inactiva (I)");

                entity.Property(e => e.VigFechaFinal).HasComment("Fecha final de la vigencia");

                entity.Property(e => e.VigFechaInicio).HasComment("Fecha de inicio para la vigencia");

                entity.Property(e => e.VigNombre)
                    .IsUnicode(false)
                    .HasComment("Nombre de la vigencia");

                entity.Property(e => e.VigPlazoDocumentacion).HasComment("Número de días que tiene el proponente para entregar la documentación.");
            });

            modelBuilder.Entity<BasDependencias>(entity =>
            {
                entity.Property(e => e.DepId).ValueGeneratedOnAdd();

                entity.Property(e => e.DepDireccion).IsUnicode(false);

                entity.Property(e => e.DepNombre).IsUnicode(false);

                entity.Property(e => e.DepTelefonos).IsUnicode(false);
            });

            modelBuilder.Entity<BasEntidadesFinancieras>(entity =>
            {
                entity.Property(e => e.EntId)
                    .HasComment("Identificador único de la entidad")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EntNombre)
                    .IsUnicode(false)
                    .HasComment("Nombre de la entidad");

                entity.Property(e => e.EntVisible).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
            });

            modelBuilder.Entity<BasTiposProyectos>(entity =>
            {
                entity.Property(e => e.TipId).ValueGeneratedOnAdd();

                entity.Property(e => e.TipInstancia)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipNombre).IsUnicode(false);

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.BasTiposProyectos)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BAS_TIPOS_PROYECTOS_APP_VIGENCIAS");
            });

            modelBuilder.Entity<BasZonasGeograficas>(entity =>
            {
                entity.Property(e => e.ZonId).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.Property(e => e.ZonCategoria).IsUnicode(false);

                entity.Property(e => e.ZonNombre).IsUnicode(false);

                entity.Property(e => e.ZonPadreId).IsUnicode(false);

                entity.Property(e => e.ZonPoblacion).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Cuentausuario>(entity =>
            {
                entity.HasComment("Almacena los usuarios del sistema");

                entity.Property(e => e.Cuentausuarioid).HasComment("Id de la tabla");

                entity.Property(e => e.Cuentausuarioclave)
                    .IsUnicode(false)
                    .HasComment("Clave encriptada del usuario");

                entity.Property(e => e.Cuentausuariodominio).HasComment("Indica si la cuenta pertenece al LDAP");

                entity.Property(e => e.Cuentausuarioemail)
                    .IsUnicode(false)
                    .HasComment("Email del usuario");

                entity.Property(e => e.Cuentausuariofechaactualizacionclave).HasComment("Fecha en la que actualizó la clave por última vez");

                entity.Property(e => e.Cuentausuariohabilitada).HasComment("Estado del usuario (Activo e Inactivo)");

                entity.Property(e => e.Cuentausuariohistorialclave)
                    .IsUnicode(false)
                    .HasComment("Se almacenan datos relacionados con el cambio de clave");

                entity.Property(e => e.Cuentausuarionumerointentos).HasComment("Conteo del número de intentos fallidos del usuario");

                entity.Property(e => e.Cuentausuarioplazoprimerlogeo).HasComment("Fecha en la que vence el primer logeo");

                entity.Property(e => e.Cuentausuariosesionid)
                    .IsUnicode(false)
                    .HasComment("Sessión del usuario autenticado");

                entity.Property(e => e.Cuentausuariousuario)
                    .IsUnicode(false)
                    .HasComment("Nombre de usuario (Único)");

                entity.Property(e => e.Cuentausuariovencimiento).HasComment("Fecha en la que vence la clave");

                entity.Property(e => e.Personaid).HasComment("Persona a la que pertenece el usario");
            });

            modelBuilder.Entity<Logacciones>(entity =>
            {
                entity.Property(e => e.Logip).IsUnicode(false);

                entity.Property(e => e.Logkey).IsUnicode(false);

                entity.Property(e => e.Logtipoaccion)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Logtraza).IsUnicode(false);

                entity.Property(e => e.Logusuario).IsUnicode(false);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasComment("ALMACENA LOS PERFILES DE LAS CUENTAS DE USUARIO");

                entity.HasIndex(e => e.Perfilnombre)
                    .HasName("UIX_PERFIL")
                    .IsUnique();

                entity.Property(e => e.Perfilid).HasComment("IDENTIFICADOR DEL PERFIL");

                entity.Property(e => e.Perfilhabilitado).HasComment("INDICADOR (1)HABILITADO (0)DESHABILITADO");

                entity.Property(e => e.Perfilnombre)
                    .IsUnicode(false)
                    .HasComment("NOMBRE DEL PERFIL");

                entity.Property(e => e.Perfiltipo)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("TIPO DEL PERFIL (I)NTERNO, (E)XTERNO");
            });

            modelBuilder.Entity<PerfilesCuentausuario>(entity =>
            {
                entity.HasComment("Almacena los perfiles asociados a las cuentas de usuario");

                entity.HasIndex(e => new { e.Perfilid, e.Cuentausuarioid })
                    .HasName("UIX_PERFILES_CUENTAUSUARIO")
                    .IsUnique();

                entity.Property(e => e.PerfilesCuentausuarioid).HasComment("Identificador de la relacion del perfil y la cuenta de usuario");

                entity.Property(e => e.Cuentausuarioid).HasComment("Identificador de la cuenta de usuario");

                entity.Property(e => e.Perfilid).HasComment("Identificador del perfil");

                entity.HasOne(d => d.Cuentausuario)
                    .WithMany(p => p.PerfilesCuentausuario)
                    .HasForeignKey(d => d.Cuentausuarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERFILES_CUENTAUSUARIO_CUENTAUSUARIO");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.PerfilesCuentausuario)
                    .HasForeignKey(d => d.Perfilid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PERFILES_USUARIO_PERFIL");
            });

            modelBuilder.Entity<PlantillaCorreos>(entity =>
            {
                entity.HasKey(e => e.Codigoplantillacorreos)
                    .HasName("PK_PLANTILLACORREOS");

                entity.Property(e => e.Codigoplantillacorreos).IsUnicode(false);

                entity.Property(e => e.Asunto).IsUnicode(false);

                entity.Property(e => e.Cuerpo).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
            });

            modelBuilder.Entity<PreguntaSeguridad>(entity =>
            {
                entity.Property(e => e.Pregunta).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);
            });

            modelBuilder.Entity<PreguntaUsuario>(entity =>
            {
                entity.Property(e => e.Cuentausuarioid).HasComment("Id de la tabla");

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.Property(e => e.UsuCreo).IsUnicode(false);

                entity.Property(e => e.UsuModifico).IsUnicode(false);

                entity.HasOne(d => d.Cuentausuario)
                    .WithMany(p => p.PreguntaUsuario)
                    .HasForeignKey(d => d.Cuentausuarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PREGUNTA_USUARIO_CUENTAUSUARIO");

                entity.HasOne(d => d.IdpreguntaNavigation)
                    .WithMany(p => p.PreguntaUsuario)
                    .HasForeignKey(d => d.Idpregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PREGUNTA_USUARIO_PREGUNTA_SEGURIDAD");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasComment("ALMACENA LOS SERVICIOS DEL SISTEMA");

                entity.HasIndex(e => e.Servicionombre)
                    .HasName("UIX_SERVICIO")
                    .IsUnique();

                entity.Property(e => e.Servicioid)
                    .HasComment("IDENTIFICADOR DEL SERVICIO")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Servicioactivo).HasComment("INDICADOR (1)ACTIVO EN MENÚ, (0)NO ACTIVO EN MENÚ");

                entity.Property(e => e.Serviciohabilitado).HasComment("INDICADOR (1)HABILITADO, (0)NO HABILITADO");

                entity.Property(e => e.Servicioicono).IsUnicode(false);

                entity.Property(e => e.Servicionivel)
                    .HasComment("NIVEL DEL SERVICIO")
                    .HasComputedColumnSql("([SERVICIOJERARQUIA].[GetLevel]())");

                entity.Property(e => e.Servicionombre)
                    .IsUnicode(false)
                    .HasComment("NOMBRE DEL SERVICIO");

                entity.Property(e => e.Servicioreferenciareporte).HasComment("INDICADOR (1)REFERENCIA REPORTE (0)NO REFERENCIA REPORTE");

                entity.Property(e => e.Serviciotipo)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("INDICA SI EL SERVICIO ES (P)UBLICO O P(R)IVADO");

                entity.Property(e => e.Serviciovista)
                    .IsUnicode(false)
                    .HasComment("RUTA DONDE SE ENCUENTRA LA VISTA ASOCIADA A LA CAPA DE PRESENTACION (WEB)");
            });

            modelBuilder.Entity<ServiciosPerfil>(entity =>
            {
                entity.HasComment("Almacena los servicios asociados a los perfiles");

                entity.HasIndex(e => new { e.Servicioid, e.Perfilid })
                    .HasName("UIX_SERVICIOS_PERFIL")
                    .IsUnique();

                entity.Property(e => e.ServiciosPerfilid).HasComment("Identificador de la relacion del servicio y el perfil");

                entity.Property(e => e.Perfilid).HasComment("Identificador del perfil");

                entity.Property(e => e.Servicioid).HasComment("Identificador del servicio");

                entity.HasOne(d => d.Perfil)
                    .WithMany(p => p.ServiciosPerfil)
                    .HasForeignKey(d => d.Perfilid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICIOS_PERFIL_PERFIL");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.ServiciosPerfil)
                    .HasForeignKey(d => d.Servicioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICIOS_PERFIL_SERVICIO");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Tipoidentificacionid).IsUnicode(false);

                entity.Property(e => e.Numeroid).IsUnicode(false);

                entity.Property(e => e.Primernombre).IsUnicode(false);

                entity.Property(e => e.Segundonombre).IsUnicode(false);

                entity.Property(e => e.Primerapellido).IsUnicode(false);

                entity.Property(e => e.Segundoapellido).IsUnicode(false);

                entity.Property(e => e.Genero).IsUnicode(false);

                entity.Property(e => e.Nombrecompleto).IsUnicode(false);

                //entity.Property(e => e.Id).HasComment("Identificador de la tabla");

                //entity.Property(e => e.Genero)
                //    .IsUnicode(false)
                //    .IsFixedLength()
                //    .HasComment("Genero M, F");

                //entity.Property(e => e.Nombrecompleto)
                //    .IsUnicode(false)
                //    .HasComment("Nombre completo de la persona");

                //entity.Property(e => e.Numeroid)
                //    .IsUnicode(false)
                //    .HasComment("Número de identificación de la persona");

                //entity.Property(e => e.Primerapellido)
                //    .IsUnicode(false)
                //    .HasComment("Primer apellido de la persona");

                //entity.Property(e => e.Primernombre)
                //    .IsUnicode(false)
                //    .HasComment("Primer nombre de la persona");

                //entity.Property(e => e.Segundoapellido)
                //    .IsUnicode(false)
                //    .HasComment("Segundo apellido de la persona");

                //entity.Property(e => e.Segundonombre)
                //    .IsUnicode(false)
                //    .HasComment("Segundo nombre de la persona");

                //entity.Property(e => e.Tipoidentificacionid).HasComment("Tipo de identificación de la persona, 1 = CC");
            });

            modelBuilder.Entity<Trayectoria>(entity =>
            {
                entity.Property(e => e.TRA_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.TRA_PREGUNTA).IsUnicode(false);

                entity.Property(e => e.TTR_ID).IsUnicode(false);

                entity.Property(e => e.VIG_ID).IsUnicode(false);

            });


            modelBuilder.Entity<PresupuestoParametrizacionLineasTope>(entity =>
            {
                entity.Property(e => e.PPL_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.ZON_ID).IsUnicode(false);

                entity.Property(e => e.LIN_ID).IsUnicode(false);

                entity.Property(e => e.VALOR_TOPE_PRESUPUESTO).IsUnicode(false);

            });

            modelBuilder.Entity<TipoTrayectoria>(entity =>
            {
                entity.Property(e => e.TTR_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.TTR_NOMBRE).IsUnicode(false);

                entity.Property(e => e.TTR_ACTIVO).IsUnicode(false);


            });

            modelBuilder.Entity<TrayectoriaProyecto>(entity =>
            {
                entity.Property(e => e.TPR_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.TPR_RESPUESTA_TRAYECTORIA).IsUnicode(false);

                entity.Property(e => e.TRA_ID).IsUnicode(false);

                entity.Property(e => e.PRO_ID).IsUnicode(false);

                // entity.Property(e => e.TTR_ID).IsUnicode(false);


            });

            modelBuilder.Entity<AppPresupuestoDetalleTipoTitulos>(entity =>
            {
                entity.Property(e => e.ATT_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.ATT_DESCRIPCION).IsUnicode(false);

                entity.Property(e => e.ATT_ORDEN).IsUnicode(false);

            });

            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.Property(e => e.PRO_ID).ValueGeneratedOnAdd();

                entity.Property(e => e.PRO_NUMERO_RADICACION).IsUnicode(false);

                entity.Property(e => e.PRO_NOMBRE).IsUnicode(false);

                entity.Property(e => e.PRO_RAZON_SOCIAL).IsUnicode(false);

                entity.Property(e => e.PRO_FECHA_INICIAL).IsUnicode(false);

                entity.Property(e => e.PRO_FECHA_FINAL).IsUnicode(false);

                entity.Property(e => e.PRO_ESTADO).IsUnicode(false);

                entity.Property(e => e.PRO_OBSERVACIONES).IsUnicode(false);

                entity.Property(e => e.LIN_NOMBRE).IsUnicode(false);

                entity.Property(e => e.Ubicacion).IsUnicode(false);

                entity.Property(e => e.Area).IsUnicode(false);

            });

            modelBuilder.Entity<AdmConfiguracion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ADM_CONFIGURACION");

                entity.Property(e => e.AdmPerfilSupervisores)
                    .HasColumnName("ADM_PERFIL_SUPERVISORES")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<AdmPerfiles>(entity =>
            {
                entity.HasKey(e => e.PerId);

                entity.ToTable("ADM_PERFILES");

                entity.Property(e => e.PerId)
                    .HasColumnName("PER_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PerDescripcion)
                    .HasColumnName("PER_DESCRIPCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PerEstado)
                    .IsRequired()
                    .HasColumnName("PER_ESTADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PerFechaActualizacion)
                    .HasColumnName("PER_FECHA_ACTUALIZACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.PerFechaCreacion)
                    .HasColumnName("PER_FECHA_CREACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.PerNombre)
                    .IsRequired()
                    .HasColumnName("PER_NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PerTipo)
                    .HasColumnName("PER_TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<AdmPerfilesUsuarios>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ADM_PERFILES_USUARIOS");

                entity.Property(e => e.PerId)
                    .HasColumnName("PER_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UsuId)
                    .HasColumnName("USU_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Per)
                    .WithMany()
                    .HasForeignKey(d => d.PerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADM_PERFILES_USUARIOS_ADM_PERFILES");
            });



            modelBuilder.Entity<AdmUsuarios>(entity =>
            {
                entity.HasKey(e => e.UsuId);

                entity.ToTable("ADM_USUARIOS");

                entity.Property(e => e.UsuId)
                    .HasColumnName("USU_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                //entity.Property(e => e.DepId)
                //    .HasColumnName("DEP_ID")
                //    .HasColumnType("numeric(18, 0)");

                //entity.Property(e => e.UsuActividadRelacionadaCultura)
                //    .HasColumnName("USU_ACTIVIDAD_RELACIONADA_CULTURA")
                //    .HasMaxLength(1)
                //    .IsUnicode(false)
                //    .IsFixedLength();

                //entity.Property(e => e.UsuAdministrador)
                //    .HasColumnName("USU_ADMINISTRADOR")
                //    .HasMaxLength(1)
                //    .IsUnicode(false)
                //    .IsFixedLength();

                //entity.Property(e => e.UsuCambioClave)
                //    .HasColumnName("USU_CAMBIO_CLAVE")
                //    .HasMaxLength(1)
                //    .IsUnicode(false)
                //    .IsFixedLength();

                entity.Property(e => e.UsuCargo)
                    .HasColumnName("USU_CARGO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                //entity.Property(e => e.UsuClave)
                //    .IsRequired()
                //    .HasColumnName("USU_CLAVE")
                //    .HasMaxLength(50)
                //    .IsUnicode(false);

                entity.Property(e => e.UsuCorreoElectronico)
                    .IsRequired()
                    .HasColumnName("USU_CORREO_ELECTRONICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                //entity.Property(e => e.UsuDiasExpiracion).HasColumnName("USU_DIAS_EXPIRACION");

                entity.Property(e => e.UsuDireccion)
                    .HasColumnName("USU_DIRECCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                //entity.Property(e => e.UsuEstado)
                //    .IsRequired()
                //    .HasColumnName("USU_ESTADO")
                //    .HasMaxLength(1)
                //    .IsUnicode(false)
                //    .IsFixedLength();

                //entity.Property(e => e.UsuFechaActualizacion)
                //    .HasColumnName("USU_FECHA_ACTUALIZACION")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.UsuFechaCambioClave)
                //    .HasColumnName("USU_FECHA_CAMBIO_CLAVE")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.UsuFechaCreacion)
                //    .HasColumnName("USU_FECHA_CREACION")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.UsuFechaNacimiento)
                //    .HasColumnName("USU_FECHA_NACIMIENTO")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.UsuFechaUltimoIngreso)
                //    .HasColumnName("USU_FECHA_ULTIMO_INGRESO")
                //    .HasColumnType("datetime");

                //entity.Property(e => e.UsuFirma)
                //    .HasColumnName("USU_FIRMA")
                //    .HasMaxLength(2000)
                //    .IsUnicode(false);

                //entity.Property(e => e.UsuGenero)
                //    .HasColumnName("USU_GENERO")
                //    .HasMaxLength(1)
                //    .IsUnicode(false)
                //    .IsFixedLength();

                //entity.Property(e => e.UsuIntentosFallidosIngreso).HasColumnName("USU_INTENTOS_FALLIDOS_INGRESO");

                entity.Property(e => e.UsuNombre)
                    .IsRequired()
                    .HasColumnName("USU_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                //entity.Property(e => e.UsuRecibirInfoTemasInteres)
                //    .HasColumnName("USU_RECIBIR_INFO_TEMAS_INTERES")
                //    .HasMaxLength(1)
                //    .IsUnicode(false)
                //    .IsFixedLength();

                //entity.Property(e => e.UsuRevisorEstilo)
                //    .HasColumnName("USU_REVISOR_ESTILO")
                //    .HasMaxLength(1)
                //    .IsUnicode(false)
                //    .IsFixedLength();

                entity.Property(e => e.UsuTelefono)
                    .HasColumnName("USU_TELEFONO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UsuTipo)
                    .IsRequired()
                    .HasColumnName("USU_TIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuUsuario)
                    .IsRequired()
                    .HasColumnName("USU_USUARIO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                //entity.Property(e => e.ZonId)
                //    .HasColumnName("ZON_ID")
                //    .HasMaxLength(5)
                //    .IsUnicode(false);

                //entity.Property(e => e.ZopId).HasColumnName("ZOP_ID");
            });


            modelBuilder.Entity<ConZonas>(entity =>
            {
                entity.Property(e => e.ZonId).ValueGeneratedOnAdd();

                entity.Property(e => e.ZonaNombre).IsUnicode(false);

                

            });

            modelBuilder.Entity<ConEstados>(entity =>
            {
                entity.Property(e => e.ProEstado).ValueGeneratedOnAdd();

                entity.Property(e => e.ProNombreEstado).IsUnicode(false);



            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
