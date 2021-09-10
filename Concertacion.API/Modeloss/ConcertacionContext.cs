using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Concertacion.API.Modeloss
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

        public virtual DbSet<AdjuntoCorreos> AdjuntoCorreos { get; set; }
        public virtual DbSet<AdmConfiguracion> AdmConfiguracion { get; set; }
        public virtual DbSet<AdmPerfiles> AdmPerfiles { get; set; }
        public virtual DbSet<AdmPerfilesUsuarios> AdmPerfilesUsuarios { get; set; }
        public virtual DbSet<AdmUsuarios> AdmUsuarios { get; set; }
        public virtual DbSet<AppActividadesObligatorias> AppActividadesObligatorias { get; set; }
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
        public virtual DbSet<AppPresupuestoDetalle> AppPresupuestoDetalle { get; set; }
        public virtual DbSet<AppPresupuestoDetalleTipo> AppPresupuestoDetalleTipo { get; set; }
        public virtual DbSet<AppPresupuestoDetalleTipoTitulos> AppPresupuestoDetalleTipoTitulos { get; set; }
        public virtual DbSet<AppPresupuestoTipoCampo> AppPresupuestoTipoCampo { get; set; }
        public virtual DbSet<AppProponentes> AppProponentes { get; set; }
        public virtual DbSet<AppProyectoActividadesObligatorias> AppProyectoActividadesObligatorias { get; set; }
        public virtual DbSet<AppProyectos> AppProyectos { get; set; }
        public virtual DbSet<AppProyectosCronograma> AppProyectosCronograma { get; set; }
        public virtual DbSet<AppPuntajeProyecto> AppPuntajeProyecto { get; set; }
        public virtual DbSet<AppRadicadoProyectos> AppRadicadoProyectos { get; set; }
        public virtual DbSet<AppRangos> AppRangos { get; set; }
        public virtual DbSet<AppRegistroRechazados> AppRegistroRechazados { get; set; }
        public virtual DbSet<AppRequisitos> AppRequisitos { get; set; }
        public virtual DbSet<AppTemas> AppTemas { get; set; }
        public virtual DbSet<AppTemasProyectos> AppTemasProyectos { get; set; }
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
        public virtual DbSet<EnvioCorreos> EnvioCorreos { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Logacciones> Logacciones { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<PerfilesCuentausuario> PerfilesCuentausuario { get; set; }
        public virtual DbSet<PlantillaCorreos> PlantillaCorreos { get; set; }
        public virtual DbSet<PreguntaSeguridad> PreguntaSeguridad { get; set; }
        public virtual DbSet<PreguntaUsuario> PreguntaUsuario { get; set; }
        public virtual DbSet<PresupuestoParametrizacionLineasTope> PresupuestoParametrizacionLineasTope { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<ServiciosPerfil> ServiciosPerfil { get; set; }
        public virtual DbSet<TipoTrayectoria> TipoTrayectoria { get; set; }
        public virtual DbSet<Trayectoria> Trayectoria { get; set; }
        public virtual DbSet<TrayectoriaProyecto> TrayectoriaProyecto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DKAU0FA;Database=Concertacion;Trusted_Connection=True;User Id=concertacion;Password=concertacion;Integrated Security=false;", x => x.UseHierarchyId());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdjuntoCorreos>(entity =>
            {
                entity.ToTable("ADJUNTO_CORREOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaCreo)
                    .HasColumnName("FECHA_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEnvio).HasColumnName("ID_ENVIO");

                entity.Property(e => e.NombreAdjunto)
                    .IsRequired()
                    .HasColumnName("NOMBRE_ADJUNTO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RutaAdjunto)
                    .IsRequired()
                    .HasColumnName("RUTA_ADJUNTO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnvioNavigation)
                    .WithMany(p => p.AdjuntoCorreos)
                    .HasForeignKey(d => d.IdEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ADJUNTO_CORREOS_ENVIO_CORREOS");
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

                entity.Property(e => e.DepId)
                    .HasColumnName("DEP_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UsuActividadRelacionadaCultura)
                    .HasColumnName("USU_ACTIVIDAD_RELACIONADA_CULTURA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuAdministrador)
                    .HasColumnName("USU_ADMINISTRADOR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuCambioClave)
                    .HasColumnName("USU_CAMBIO_CLAVE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuCargo)
                    .HasColumnName("USU_CARGO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuClave)
                    .IsRequired()
                    .HasColumnName("USU_CLAVE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCorreoElectronico)
                    .IsRequired()
                    .HasColumnName("USU_CORREO_ELECTRONICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuDiasExpiracion).HasColumnName("USU_DIAS_EXPIRACION");

                entity.Property(e => e.UsuDireccion)
                    .HasColumnName("USU_DIRECCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuEstado)
                    .IsRequired()
                    .HasColumnName("USU_ESTADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuFechaActualizacion)
                    .HasColumnName("USU_FECHA_ACTUALIZACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuFechaCambioClave)
                    .HasColumnName("USU_FECHA_CAMBIO_CLAVE")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuFechaCreacion)
                    .HasColumnName("USU_FECHA_CREACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuFechaNacimiento)
                    .HasColumnName("USU_FECHA_NACIMIENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuFechaUltimoIngreso)
                    .HasColumnName("USU_FECHA_ULTIMO_INGRESO")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuFirma)
                    .HasColumnName("USU_FIRMA")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.UsuGenero)
                    .HasColumnName("USU_GENERO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuIntentosFallidosIngreso).HasColumnName("USU_INTENTOS_FALLIDOS_INGRESO");

                entity.Property(e => e.UsuNombre)
                    .IsRequired()
                    .HasColumnName("USU_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuRecibirInfoTemasInteres)
                    .HasColumnName("USU_RECIBIR_INFO_TEMAS_INTERES")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UsuRevisorEstilo)
                    .HasColumnName("USU_REVISOR_ESTILO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

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

                entity.Property(e => e.ZonId)
                    .HasColumnName("ZON_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ZopId).HasColumnName("ZOP_ID");
            });

            modelBuilder.Entity<AppActividadesObligatorias>(entity =>
            {
                entity.HasKey(e => e.ActId);

                entity.ToTable("APP_ACTIVIDADES_OBLIGATORIAS");

                entity.Property(e => e.ActId)
                    .HasColumnName("ACT_ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActActividad)
                    .HasColumnName("ACT_ACTIVIDAD")
                    .IsUnicode(false);

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppAreas>(entity =>
            {
                entity.HasKey(e => e.AreId);

                entity.ToTable("APP_AREAS");

                entity.Property(e => e.AreId)
                    .HasColumnName("ARE_ID")
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("Identificador único del área")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AreNombre)
                    .HasColumnName("ARE_NOMBRE")
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasComment("Nombre del área");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador de la vigencia.");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppAreas)
                    .HasForeignKey(d => d.VigId)
                    .HasConstraintName("FK_APP_VIGENCIAS_APP_AREAS");
            });

            modelBuilder.Entity<AppBeneficiarios>(entity =>
            {
                entity.HasKey(e => e.BenId);

                entity.ToTable("APP_BENEFICIARIOS");

                entity.Property(e => e.BenId)
                    .HasColumnName("BEN_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BeeTotalBeneficiados)
                    .HasColumnName("BEE_TOTAL_BENEFICIADOS")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BenCaracteristicasPoblacion)
                    .HasColumnName("BEN_CARACTERISTICAS_POBLACION")
                    .IsUnicode(false);

                entity.Property(e => e.BenNumeroArtistasInternacionales)
                    .HasColumnName("BEN_NUMERO_ARTISTAS_INTERNACIONALES")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BenNumeroArtistasNacionales)
                    .HasColumnName("BEN_NUMERO_ARTISTAS_NACIONALES")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BenOtrasPersonasBeneficiadasDescripcion).HasColumnName("BEN_OTRAS_PERSONAS_BENEFICIADAS_DESCRIPCION");

                entity.Property(e => e.BenPersonasAsistentes)
                    .HasColumnName("BEN_PERSONAS_ASISTENTES")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.BenPersonasLogistica)
                    .HasColumnName("BEN_PERSONAS_LOGISTICA")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

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

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppBeneficiarios)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_BENEFICIARIOS_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppCausalesRechazo>(entity =>
            {
                entity.HasKey(e => e.CauId);

                entity.ToTable("APP_CAUSALES_RECHAZO");

                entity.Property(e => e.CauId)
                    .HasColumnName("CAU_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CauDescripcion)
                    .IsRequired()
                    .HasColumnName("CAU_DESCRIPCION")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.CauNombre)
                    .IsRequired()
                    .HasColumnName("CAU_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Nombre de la causal de rexhazo");

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppCausalesRechazo)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_CAUSALES_RECHAZO_APP_VIGENCIAS");
            });

            modelBuilder.Entity<AppComponentes>(entity =>
            {
                entity.HasKey(e => e.ComId);

                entity.ToTable("APP_COMPONENTES");

                entity.Property(e => e.ComId)
                    .HasColumnName("COM_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ComDescripcion)
                    .HasColumnName("COM_DESCRIPCION")
                    .HasColumnType("text");

                entity.Property(e => e.ComEmpleosDescripcion)
                    .HasColumnName("COM_EMPLEOS_DESCRIPCION")
                    .HasColumnType("text");

                entity.Property(e => e.ComEmpleosDescripcion2)
                    .HasColumnName("COM_EMPLEOS_DESCRIPCION_2")
                    .HasColumnType("text");

                entity.Property(e => e.ComEmpleosDirectosTerminoFijo)
                    .HasColumnName("COM_EMPLEOS_DIRECTOS_TERMINO_FIJO")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ComEmpleosDirectosTerminoIndefinido)
                    .HasColumnName("COM_EMPLEOS_DIRECTOS_TERMINO_INDEFINIDO")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ComEmpleosDirectosTerminoNombramientos)
                    .HasColumnName("COM_EMPLEOS_DIRECTOS_TERMINO_NOMBRAMIENTOS")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ComEmpleosIndirectos)
                    .HasColumnName("COM_EMPLEOS_INDIRECTOS")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ComEmpleosTotal)
                    .HasColumnName("COM_EMPLEOS_TOTAL")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ComFechaFinalFestival)
                    .HasColumnName("COM_FECHA_FINAL_FESTIVAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComFechaInicioFestival)
                    .HasColumnName("COM_FECHA_INICIO_FESTIVAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.ComJustificacion)
                    .HasColumnName("COM_JUSTIFICACION")
                    .HasColumnType("text");

                entity.Property(e => e.ComJustificacion2)
                    .HasColumnName("COM_JUSTIFICACION_2")
                    .HasColumnType("text");

                entity.Property(e => e.ComMetas)
                    .HasColumnName("COM_METAS")
                    .HasColumnType("text");

                entity.Property(e => e.ComMetasB)
                    .HasColumnName("COM_METAS_B")
                    .HasColumnType("text");

                entity.Property(e => e.ComMetasC)
                    .HasColumnName("COM_METAS_C")
                    .HasColumnType("text");

                entity.Property(e => e.ComMetasD)
                    .HasColumnName("COM_METAS_D")
                    .HasColumnType("text");

                entity.Property(e => e.ComMetasE)
                    .HasColumnName("COM_METAS_E")
                    .HasColumnType("text");

                entity.Property(e => e.ComMetasF)
                    .HasColumnName("COM_METAS_F")
                    .HasColumnType("text");

                entity.Property(e => e.ComObjetivoGeneral)
                    .HasColumnName("COM_OBJETIVO_GENERAL")
                    .HasColumnType("text");

                entity.Property(e => e.ComObjetivosEspecificos)
                    .HasColumnName("COM_OBJETIVOS_ESPECIFICOS")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaAntiguos1)
                    .HasColumnName("COM_TRAYECTORIA_ANTIGUOS_1")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaAntiguos2)
                    .HasColumnName("COM_TRAYECTORIA_ANTIGUOS_2")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaAntiguos3)
                    .HasColumnName("COM_TRAYECTORIA_ANTIGUOS_3")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaAntiguos4)
                    .HasColumnName("COM_TRAYECTORIA_ANTIGUOS_4")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaAntiguos5)
                    .HasColumnName("COM_TRAYECTORIA_ANTIGUOS_5")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaAntiguos5b)
                    .HasColumnName("COM_TRAYECTORIA_ANTIGUOS_5B")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaNuevos1)
                    .HasColumnName("COM_TRAYECTORIA_NUEVOS_1")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaNuevos2)
                    .HasColumnName("COM_TRAYECTORIA_NUEVOS_2")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaNuevos3)
                    .HasColumnName("COM_TRAYECTORIA_NUEVOS_3")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaNuevos4)
                    .HasColumnName("COM_TRAYECTORIA_NUEVOS_4")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaNuevos4b)
                    .HasColumnName("COM_TRAYECTORIA_NUEVOS_4B")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaNuevos5)
                    .HasColumnName("COM_TRAYECTORIA_NUEVOS_5")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaProyecto)
                    .HasColumnName("COM_TRAYECTORIA_PROYECTO")
                    .HasColumnType("text");

                entity.Property(e => e.ComTrayectoriaSeleccion)
                    .HasColumnName("COM_TRAYECTORIA_SELECCION")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

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

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppComponentes)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_COMPONENTES_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppContratacion>(entity =>
            {
                entity.ToTable("APP_CONTRATACION");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConAbogado)
                    .HasColumnName("CON_ABOGADO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ConActa)
                    .HasColumnName("CON_ACTA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConAnexos)
                    .HasColumnName("CON_ANEXOS")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConCdp)
                    .HasColumnName("CON_CDP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConContratando)
                    .HasColumnName("CON_CONTRATANDO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConConveniofirmado)
                    .HasColumnName("CON_CONVENIOFIRMADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConCorreeosupervisor)
                    .HasColumnName("CON_CORREEOSUPERVISOR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConCorreofinalizacion)
                    .HasColumnName("CON_CORREOFINALIZACION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConCrp)
                    .HasColumnName("CON_CRP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConEvaluacion)
                    .HasColumnName("CON_EVALUACION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConFechaLiqContratos)
                    .HasColumnName("CON_FECHA_LIQ_CONTRATOS")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConFechaLiquidacion)
                    .HasColumnName("CON_FECHA_LIQUIDACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConFechaRadContratos)
                    .HasColumnName("CON_FECHA_RAD_CONTRATOS")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConFechaacta)
                    .HasColumnName("CON_FECHAACTA")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConFechacdp)
                    .HasColumnName("CON_FECHACDP")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConFechafin)
                    .HasColumnName("CON_FECHAFIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConFechainicio)
                    .HasColumnName("CON_FECHAINICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConFechasuscripcion)
                    .HasColumnName("CON_FECHASUSCRIPCION")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConFormaPago)
                    .HasColumnName("CON_FORMA_PAGO")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ConFormatoA)
                    .HasColumnName("CON_FORMATO_A")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConFormatoB)
                    .HasColumnName("CON_FORMATO_B")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConGarantiaCumpDesde)
                    .HasColumnName("CON_GARANTIA_CUMP_DESDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConGarantiaCumpHasta)
                    .HasColumnName("CON_GARANTIA_CUMP_HASTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConGarantiaCumpOk)
                    .HasColumnName("CON_GARANTIA_CUMP_OK")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConGarantiaManejoDesde)
                    .HasColumnName("CON_GARANTIA_MANEJO_DESDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConGarantiaManejoHasta)
                    .HasColumnName("CON_GARANTIA_MANEJO_HASTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConGarantiaManejoOk)
                    .HasColumnName("CON_GARANTIA_MANEJO_OK")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConGarantiaSalarioDesde)
                    .HasColumnName("CON_GARANTIA_SALARIO_DESDE")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConGarantiaSalarioHasta)
                    .HasColumnName("CON_GARANTIA_SALARIO_HASTA")
                    .HasColumnType("datetime");

                entity.Property(e => e.ConGarantiaSalarioOk)
                    .HasColumnName("CON_GARANTIA_SALARIO_OK")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConLinksecop)
                    .HasColumnName("CON_LINKSECOP")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ConNotificado).HasColumnName("CON_NOTIFICADO");

                entity.Property(e => e.ConNumProcesoSecop)
                    .HasColumnName("CON_NUM_PROCESO_SECOP")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ConNumeroconvenio)
                    .HasColumnName("CON_NUMEROCONVENIO")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ConRegistropresup)
                    .HasColumnName("CON_REGISTROPRESUP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConRegistropresupSN)
                    .HasColumnName("CON_REGISTROPRESUP_S_N")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConTotalfolios)
                    .HasColumnName("CON_TOTALFOLIOS")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ConUsuario)
                    .HasColumnName("CON_USUARIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ConValoradicion)
                    .HasColumnName("CON_VALORADICION")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ConValorconvenio)
                    .HasColumnName("CON_VALORCONVENIO")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DepId)
                    .HasColumnName("DEP_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EscId)
                    .HasColumnName("ESC_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

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
                entity.HasKey(e => e.DetId);

                entity.ToTable("APP_DETALLE_TIPOS_ENTIDADES");

                entity.Property(e => e.DetId)
                    .HasColumnName("DET_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DetNombre)
                    .IsRequired()
                    .HasColumnName("DET_NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DetNumeroProyectos).HasColumnName("DET_NUMERO_PROYECTOS");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.TipId).HasColumnName("TIP_ID");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.AppDetalleTiposEntidades)
                    .HasForeignKey(d => d.TipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_DETALLE_TIPOS_ENTIDADES_APP_TIPOS_ENTIDADES");
            });

            modelBuilder.Entity<AppDocumentosTipoEntidades>(entity =>
            {
                entity.HasKey(e => new { e.TdoId, e.TipId });

                entity.ToTable("APP_DOCUMENTOS_TIPO_ENTIDADES");

                entity.Property(e => e.TdoId)
                    .HasColumnName("TDO_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TipId).HasColumnName("TIP_ID");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Obligatorio)
                    .IsRequired()
                    .HasColumnName("OBLIGATORIO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TdoNs)
                    .HasColumnName("TDO_NS")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TdoOrden)
                    .HasColumnName("TDO_ORDEN")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

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
                entity.HasKey(e => e.EscId);

                entity.ToTable("APP_ESTADO_CONTRATACION");

                entity.Property(e => e.EscId)
                    .HasColumnName("ESC_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EscNombre)
                    .HasColumnName("ESC_NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppEvaluacionRequisitos>(entity =>
            {
                entity.HasKey(e => new { e.ProId, e.ReqId });

                entity.ToTable("APP_EVALUACION_REQUISITOS");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("Identificador del proyecto");

                entity.Property(e => e.ReqId)
                    .HasColumnName("REQ_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador del requerimiento");

                entity.Property(e => e.EvaFecha)
                    .HasColumnName("EVA_FECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.EvaObservacion)
                    .HasColumnName("EVA_OBSERVACION")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Observación del por que de la calificación o el valor asignado al requisito");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.PunSolicitud)
                    .HasColumnName("PUN_SOLICITUD")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.PunValor)
                    .HasColumnName("PUN_VALOR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Indica si cumple con el requisito (S) o No cumple (N).");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

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
                entity.HasKey(e => e.IndId);

                entity.ToTable("APP_INDICADORES");

                entity.HasComment("Es es la tabla de variables");

                entity.Property(e => e.IndId)
                    .HasColumnName("IND_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IndDescripcion)
                    .HasColumnName("IND_DESCRIPCION")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.IndFormula)
                    .HasColumnName("IND_FORMULA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IndNombre)
                    .HasColumnName("IND_NOMBRE")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.IndTipo)
                    .HasColumnName("IND_TIPO")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppIndicadoresLinea>(entity =>
            {
                entity.HasKey(e => new { e.IndId, e.LinId });

                entity.ToTable("APP_INDICADORES_LINEA");

                entity.HasComment("Esta tabla es Variables por Línea");

                entity.Property(e => e.IndId)
                    .HasColumnName("IND_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador único del indicador");

                entity.Property(e => e.LinId)
                    .HasColumnName("LIN_ID")
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("Identificador de la línea");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IndOrder)
                    .HasColumnName("IND_ORDER")
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
                    .WithMany(p => p.AppIndicadoresLinea)
                    .HasForeignKey(d => d.IndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_INDICADORES_LINEA_APP_INDICADORES");

                entity.HasOne(d => d.Lin)
                    .WithMany(p => p.AppIndicadoresLinea)
                    .HasForeignKey(d => d.LinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_LINEAS_APP_INDICADORES");
            });

            modelBuilder.Entity<AppLineas>(entity =>
            {
                entity.HasKey(e => e.LinId);

                entity.ToTable("APP_LINEAS");

                entity.Property(e => e.LinId)
                    .HasColumnName("LIN_ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.LinDescripcion)
                    .HasColumnName("LIN_DESCRIPCION")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.LinDuracionMinima).HasColumnName("LIN_DURACION_MINIMA");

                entity.Property(e => e.LinNombre)
                    .HasColumnName("LIN_NOMBRE")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<AppPresupuestoDetalle>(entity =>
            {
                entity.HasKey(e => e.PdeId);

                entity.ToTable("APP_PRESUPUESTO_DETALLE");

                entity.Property(e => e.PdeId)
                    .HasColumnName("PDE_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AptId)
                    .HasColumnName("APT_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.PdeDetalleOtrosRecursos).HasColumnName("PDE_DETALLE_OTROS_RECURSOS");

                entity.Property(e => e.PdeIngresosPropios)
                    .HasColumnName("PDE_INGRESOS_PROPIOS")
                    .HasColumnType("money");

                entity.Property(e => e.PdeOtrosRecursos)
                    .HasColumnName("PDE_OTROS_RECURSOS")
                    .HasColumnType("money");

                entity.Property(e => e.PdeRecursosDepartmento)
                    .HasColumnName("PDE_RECURSOS_DEPARTMENTO")
                    .HasColumnType("money");

                entity.Property(e => e.PdeRecursosMinisterio)
                    .HasColumnName("PDE_RECURSOS_MINISTERIO")
                    .HasColumnType("money");

                entity.Property(e => e.PdeRecursosMunicipio)
                    .HasColumnName("PDE_RECURSOS_MUNICIPIO")
                    .HasColumnType("money");

                entity.Property(e => e.PdeValorTotal)
                    .HasColumnName("PDE_VALOR_TOTAL")
                    .HasColumnType("money");

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

                entity.HasOne(d => d.Apt)
                    .WithMany(p => p.AppPresupuestoDetalle)
                    .HasForeignKey(d => d.AptId)
                    .HasConstraintName("FK_APP_PRESUPUESTO_DETALLE_APP_PRESUPUESTO_DETALLE_TIPO");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppPresupuestoDetalle)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_PRESUPUESTO_DETALLE_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppPresupuestoDetalleTipo>(entity =>
            {
                entity.HasKey(e => e.AptId);

                entity.ToTable("APP_PRESUPUESTO_DETALLE_TIPO");

                entity.Property(e => e.AptId)
                    .HasColumnName("APT_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AptDescripcion)
                    .HasColumnName("APT_DESCRIPCION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AptOrden)
                    .HasColumnName("APT_ORDEN")
                    .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.AttId).HasColumnName("ATT_ID");

                entity.Property(e => e.TcpId).HasColumnName("TCP_ID");

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<AppPresupuestoDetalleTipoTitulos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("APP_PRESUPUESTO_DETALLE_TIPO_TITULOS");

                entity.Property(e => e.AttDescripcion)
                    .HasColumnName("ATT_DESCRIPCION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AttId)
                    .HasColumnName("ATT_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AttOrden).HasColumnName("ATT_ORDEN");
            });

            modelBuilder.Entity<AppPresupuestoTipoCampo>(entity =>
            {
                entity.HasKey(e => e.TcpId);

                entity.ToTable("APP_PRESUPUESTO_TIPO_CAMPO");

                entity.Property(e => e.TcpId)
                    .HasColumnName("TCP_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TcpDescripcion)
                    .HasColumnName("TCP_DESCRIPCION")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppProponentes>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("APP_PROPONENTES");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DetPropId).HasColumnName("DET_PROP_ID");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProActualizaPrimeraVez).HasColumnName("PRO_ACTUALIZA_PRIMERA_VEZ");

                entity.Property(e => e.ProBarrioComuna)
                    .HasColumnName("PRO_BARRIO_COMUNA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProCorreoElectronicoRepresentanteLegal)
                    .HasColumnName("PRO_CORREO_ELECTRONICO_REPRESENTANTE_LEGAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProDireccionRepresentanteLegal)
                    .HasColumnName("PRO_DIRECCION_REPRESENTANTE_LEGAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProDirtrad)
                    .HasColumnName("PRO_DIRTRAD")
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.ProDocumentoIdentidadRepresentanteLegal)
                    .HasColumnName("PRO_DOCUMENTO_IDENTIDAD_REPRESENTANTE_LEGAL")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProEstadoGeo)
                    .HasColumnName("PRO_ESTADO_GEO")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ProFaxRepresentanteLegal)
                    .HasColumnName("PRO_FAX_REPRESENTANTE_LEGAL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProGranContribuyente)
                    .HasColumnName("PRO_GRAN_CONTRIBUYENTE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProLatitud).HasColumnName("PRO_LATITUD");

                entity.Property(e => e.ProLongitud).HasColumnName("PRO_LONGITUD");

                entity.Property(e => e.ProLugarExpedicionDocumentoRepresentanteLegal)
                    .HasColumnName("PRO_LUGAR_EXPEDICION_DOCUMENTO_REPRESENTANTE_LEGAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProNit)
                    .HasColumnName("PRO_NIT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProPrimerApellidoRepLegal)
                    .HasColumnName("PRO_PRIMER_APELLIDO_REP_LEGAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProPrimerNombreRepLegal)
                    .HasColumnName("PRO_PRIMER_NOMBRE_REP_LEGAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProRazonSocial)
                    .HasColumnName("PRO_RAZON_SOCIAL")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProRegimenTributario)
                    .HasColumnName("PRO_REGIMEN_TRIBUTARIO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProResponsableIva)
                    .HasColumnName("PRO_RESPONSABLE_IVA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProSegundoApellidoRepLegal)
                    .HasColumnName("PRO_SEGUNDO_APELLIDO_REP_LEGAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProSegundoNombreRepLegal)
                    .HasColumnName("PRO_SEGUNDO_NOMBRE_REP_LEGAL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProTarifa)
                    .HasColumnName("PRO_TARIFA")
                    .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ProTarifaIca)
                    .HasColumnName("PRO_TARIFA_ICA")
                    .HasMaxLength(10);

                entity.Property(e => e.ProTelefonoCelular)
                    .HasColumnName("PRO_TELEFONO_CELULAR")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProTelefonosRepresentanteLegal)
                    .HasColumnName("PRO_TELEFONOS_REPRESENTANTE_LEGAL")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProTipoVinculacionPersona)
                    .HasColumnName("PRO_TIPO_VINCULACION_PERSONA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TipId).HasColumnName("TIP_ID");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZonId)
                    .HasColumnName("ZON_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ZonIdExpedicionDocumento)
                    .HasColumnName("ZON_ID_EXPEDICION_DOCUMENTO")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.AppProponentes)
                    .HasForeignKey(d => d.TipId)
                    .HasConstraintName("FK_APP_PROPONENTES_APP_TIPOS_ENTIDADES");

                entity.HasOne(d => d.Zon)
                    .WithMany(p => p.AppProponentes)
                    .HasForeignKey(d => d.ZonId)
                    .HasConstraintName("FK_APP_PROPONENTES_BAS_ZONAS_GEOGRAFICAS");
            });

            modelBuilder.Entity<AppProyectoActividadesObligatorias>(entity =>
            {
                entity.HasKey(e => e.PaoId);

                entity.ToTable("APP_PROYECTO_ACTIVIDADES_OBLIGATORIAS");

                entity.Property(e => e.PaoId)
                    .HasColumnName("PAO_ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActFechaFinal)
                    .HasColumnName("ACT_FECHA_FINAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActFechaInicio)
                    .HasColumnName("ACT_FECHA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ActId)
                    .HasColumnName("ACT_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

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

                entity.HasOne(d => d.Act)
                    .WithMany(p => p.AppProyectoActividadesObligatorias)
                    .HasForeignKey(d => d.ActId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_PROYECTO_ACTIVIDADES_OBLIGATORIAS_APP_ACTIVIDADES_OBLIGATORIAS");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppProyectoActividadesObligatorias)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_PROYECTO_ACTIVIDADES_OBLIGATORIAS_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppProyectos>(entity =>
            {
                entity.HasKey(e => e.ProId);

                entity.ToTable("APP_PROYECTOS");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AreId)
                    .HasColumnName("ARE_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AreaId1)
                    .HasColumnName("AREA_ID_1")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AreaId2)
                    .HasColumnName("AREA_ID_2")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AreaId3)
                    .HasColumnName("AREA_ID_3")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CauId)
                    .HasColumnName("CAU_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EntId)
                    .HasColumnName("ENT_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.LinId)
                    .HasColumnName("LIN_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ObservacionesProyecto).HasColumnName("OBSERVACIONES_PROYECTO");

                entity.Property(e => e.PorFechaCartaComplementacion)
                    .HasColumnName("POR_FECHA_CARTA_COMPLEMENTACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProActaAjuste)
                    .HasColumnName("PRO_ACTA_AJUSTE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProActaComite)
                    .HasColumnName("PRO_ACTA_COMITE")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProActaInicial)
                    .HasColumnName("PRO_ACTA_INICIAL")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProAplicaIncentivo).HasColumnName("PRO_APLICA_INCENTIVO");

                entity.Property(e => e.ProApoyoPropio)
                    .HasColumnName("PRO_APOYO_PROPIO")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProCelularPersonaEncargada)
                    .HasColumnName("PRO_CELULAR_PERSONA_ENCARGADA")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProCiudadEntidadFinanciera)
                    .HasColumnName("PRO_CIUDAD_ENTIDAD_FINANCIERA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProConvenio)
                    .HasColumnName("PRO_CONVENIO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProCorregimiento)
                    .HasColumnName("PRO_CORREGIMIENTO")
                    .HasMaxLength(1000);

                entity.Property(e => e.ProCorreoPersonaEncargada)
                    .HasColumnName("PRO_CORREO_PERSONA_ENCARGADA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProEnvioCartaComplementacion)
                    .HasColumnName("PRO_ENVIO_CARTA_COMPLEMENTACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProEstado)
                    .HasColumnName("PRO_ESTADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProEstadoNuevo)
                    .HasColumnName("PRO_ESTADO_NUEVO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProFechaCambioEstado)
                    .HasColumnName("PRO_FECHA_CAMBIO_ESTADO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProFechaCartaRechazo)
                    .HasColumnName("PRO_FECHA_CARTA_RECHAZO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProFechaFinal)
                    .HasColumnName("PRO_FECHA_FINAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProFechaInicial)
                    .HasColumnName("PRO_FECHA_INICIAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProFechaLegalizacion)
                    .HasColumnName("PRO_FECHA_LEGALIZACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProFechaPuntualFinal)
                    .HasColumnName("PRO_FECHA_PUNTUAL_FINAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProFechaPuntualInicial)
                    .HasColumnName("PRO_FECHA_PUNTUAL_INICIAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProFechaRadicacion)
                    .HasColumnName("PRO_FECHA_RADICACION")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProFirmado)
                    .HasColumnName("PRO_FIRMADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProGrupoLinea7)
                    .HasColumnName("PRO_GRUPO_LINEA_7")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProGrupoLinea72)
                    .HasColumnName("PRO_GRUPO_LINEA_7_2")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProGrupoLinea73)
                    .HasColumnName("PRO_GRUPO_LINEA_7_3")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProGrupoLinea74)
                    .HasColumnName("PRO_GRUPO_LINEA_7_4")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProGrupoLinea75)
                    .HasColumnName("PRO_GRUPO_LINEA_7_5")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProIdProponente)
                    .HasColumnName("PRO_ID_PROPONENTE")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProImagenOrganigrama)
                    .HasColumnName("PRO_IMAGEN_ORGANIGRAMA")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProImagenPlano)
                    .HasColumnName("PRO_IMAGEN_PLANO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ProIncentivo)
                    .HasColumnName("PRO_INCENTIVO")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProNombre)
                    .HasColumnName("PRO_NOMBRE")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProNumeroCuenta)
                    .HasColumnName("PRO_NUMERO_CUENTA")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProNumeroRadicacion)
                    .HasColumnName("PRO_NUMERO_RADICACION")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProObjeto)
                    .HasColumnName("PRO_OBJETO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ProObservaciones)
                    .HasColumnName("PRO_OBSERVACIONES")
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.ProObservacionesEvaluacion)
                    .HasColumnName("PRO_OBSERVACIONES_EVALUACION")
                    .IsUnicode(false);

                entity.Property(e => e.ProOtraArea)
                    .HasColumnName("PRO_OTRA_AREA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProOtrosMunicipios)
                    .HasColumnName("PRO_OTROS_MUNICIPIOS")
                    .IsUnicode(false);

                entity.Property(e => e.ProPeriodicidadCronograma)
                    .HasColumnName("PRO_PERIODICIDAD_CRONOGRAMA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProPersonaEncargadaProyecto)
                    .HasColumnName("PRO_PERSONA_ENCARGADA_PROYECTO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProPorcentaje)
                    .HasColumnName("PRO_PORCENTAJE")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProPuntajeTotal).HasColumnName("PRO_PUNTAJE_TOTAL");

                entity.Property(e => e.ProTelefonosPersonaEncargadaProyecto)
                    .HasColumnName("PRO_TELEFONOS_PERSONA_ENCARGADA_PROYECTO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProTema1)
                    .HasColumnName("PRO_TEMA_1")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTema2)
                    .HasColumnName("PRO_TEMA_2")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTema3)
                    .HasColumnName("PRO_TEMA_3")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea31)
                    .HasColumnName("PRO_TEMA_LINEA3_1")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea32)
                    .HasColumnName("PRO_TEMA_LINEA3_2")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea33)
                    .HasColumnName("PRO_TEMA_LINEA3_3")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea34)
                    .HasColumnName("PRO_TEMA_LINEA3_4")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea35)
                    .HasColumnName("PRO_TEMA_LINEA3_5")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea36)
                    .HasColumnName("PRO_TEMA_LINEA3_6")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea51)
                    .HasColumnName("PRO_TEMA_LINEA5_1")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea52)
                    .HasColumnName("PRO_TEMA_LINEA5_2")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea521)
                    .HasColumnName("PRO_TEMA_LINEA52_1")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea522)
                    .HasColumnName("PRO_TEMA_LINEA52_2")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea523)
                    .HasColumnName("PRO_TEMA_LINEA52_3")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea524)
                    .HasColumnName("PRO_TEMA_LINEA52_4")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea525)
                    .HasColumnName("PRO_TEMA_LINEA52_5")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea526)
                    .HasColumnName("PRO_TEMA_LINEA52_6")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea53)
                    .HasColumnName("PRO_TEMA_LINEA5_3")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea54)
                    .HasColumnName("PRO_TEMA_LINEA5_4")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea55)
                    .HasColumnName("PRO_TEMA_LINEA5_5")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTemaLinea56)
                    .HasColumnName("PRO_TEMA_LINEA5_6")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ProTipoCuenta)
                    .HasColumnName("PRO_TIPO_CUENTA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProValorAprobado)
                    .HasColumnName("PRO_VALOR_APROBADO")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProValorProyecto)
                    .HasColumnName("PRO_VALOR_PROYECTO")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProValorSolicitado)
                    .HasColumnName("PRO_VALOR_SOLICITADO")
                    .HasColumnType("decimal(10, 0)");

                entity.Property(e => e.ProVisible).HasColumnName("PRO_VISIBLE");

                entity.Property(e => e.TipId)
                    .HasColumnName("TIP_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuId)
                    .HasColumnName("USU_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UsuIdCartaComplementacion)
                    .HasColumnName("USU_ID_CARTA_COMPLEMENTACION")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioEvalua)
                    .HasColumnName("USUARIO_EVALUA")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ZonDepId)
                    .HasColumnName("ZON_DEP_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ZonId)
                    .HasColumnName("ZON_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ZonIdEntidadBancaria)
                    .HasColumnName("ZON_ID_ENTIDAD_BANCARIA")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ZonLatitud).HasColumnName("ZON_LATITUD");

                entity.Property(e => e.ZonLongitud).HasColumnName("ZON_LONGITUD");

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

            modelBuilder.Entity<AppProyectosCronograma>(entity =>
            {
                entity.HasKey(e => e.CprId);

                entity.ToTable("APP_PROYECTOS_CRONOGRAMA");

                entity.Property(e => e.CprId)
                    .HasColumnName("CPR_ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CprActividad)
                    .HasColumnName("CPR_ACTIVIDAD")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CprFechaFinal)
                    .HasColumnName("CPR_FECHA_FINAL")
                    .HasColumnType("datetime");

                entity.Property(e => e.CprFechaInicio)
                    .HasColumnName("CPR_FECHA_INICIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.CprMeta)
                    .HasColumnName("CPR_META")
                    .HasMaxLength(30);

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

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

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppProyectosCronograma)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_CRONOGRAMA_PROYECTOS_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppPuntajeProyecto>(entity =>
            {
                entity.HasKey(e => new { e.RanId, e.ProId });

                entity.ToTable("APP_PUNTAJE_PROYECTO");

                entity.Property(e => e.RanId)
                    .HasColumnName("RAN_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("Identificador del proyecto");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.PunValor)
                    .HasColumnName("PUN_VALOR")
                    .HasColumnType("numeric(18, 2)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ran)
                    .WithMany(p => p.AppPuntajeProyecto)
                    .HasForeignKey(d => d.RanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_RANGOS_APP_PUNTAJE_PROYECTO");
            });

            modelBuilder.Entity<AppRadicadoProyectos>(entity =>
            {
                entity.HasKey(e => e.NumeroRadicado);

                entity.ToTable("APP_RADICADO_PROYECTOS");

                entity.Property(e => e.NumeroRadicado).HasColumnName("NUMERO_RADICADO");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("FECHA_REGISTRO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RadicadoProyecto)
                    .IsRequired()
                    .HasColumnName("RADICADO_PROYECTO")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppRadicadoProyectos)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_RADICADO_PROYECTOS_APP_PROYECTOS");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppRadicadoProyectos)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_RADICADO_PROYECTOS_APP_VIGENCIAS");
            });

            modelBuilder.Entity<AppRangos>(entity =>
            {
                entity.HasKey(e => e.RanId);

                entity.ToTable("APP_RANGOS");

                entity.Property(e => e.RanId)
                    .HasColumnName("RAN_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.RanDescripcion)
                    .HasColumnName("RAN_DESCRIPCION")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Descripción del rango. Por ejemplo,  de 6 meses hasta 3 años");

                entity.Property(e => e.RanMaximo)
                    .HasColumnName("RAN_MAXIMO")
                    .HasColumnType("numeric(38, 20)");

                entity.Property(e => e.RanMinimo)
                    .HasColumnName("RAN_MINIMO")
                    .HasColumnType("numeric(38, 20)");

                entity.Property(e => e.RanPuntaje)
                    .HasColumnName("RAN_PUNTAJE")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Valor de puntaje asignado para cuando se seleccione este rango");

                entity.Property(e => e.RanPuntajeAbierto)
                    .HasColumnName("RAN_PUNTAJE_ABIERTO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Determina si la variable permite un valor de puntaje abierto (S) y no un rango (N)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VarId)
                    .HasColumnName("VAR_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador de la variable.");

                entity.HasOne(d => d.Var)
                    .WithMany(p => p.AppRangos)
                    .HasForeignKey(d => d.VarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VARIABLES_APP_RANGOS");
            });

            modelBuilder.Entity<AppRegistroRechazados>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("APP_REGISTRO_RECHAZADOS");

                entity.Property(e => e.ReqId)
                    .HasColumnName("REQ_ID")
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CauId)
                    .HasColumnName("CAU_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProObservaciones)
                    .HasColumnName("PRO_OBSERVACIONES")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppRegistroRechazados)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_APP_REGISTRO_RECHAZADOS_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppRequisitos>(entity =>
            {
                entity.HasKey(e => e.ReqId);

                entity.ToTable("APP_REQUISITOS");

                entity.Property(e => e.ReqId)
                    .HasColumnName("REQ_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador del requerimiento")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReqCausalRechazo)
                    .HasColumnName("REQ_CAUSAL_RECHAZO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.ReqNombre)
                    .IsRequired()
                    .HasColumnName("REQ_NOMBRE")
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasComment("Nombre o descripción del requerimiento");

                entity.Property(e => e.ReqOrden)
                    .HasColumnName("REQ_ORDEN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TipId).HasColumnName("TIP_ID");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador de la vigencia.");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppRequisitos)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VIGENCIAS_APP_REQUISITOS");
            });

            modelBuilder.Entity<AppTemas>(entity =>
            {
                entity.HasKey(e => e.TemId)
                    .HasName("PK_TEMAS");

                entity.ToTable("APP_TEMAS");

                entity.Property(e => e.TemId).HasColumnName("TEM_ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .IsUnicode(false);

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

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

                entity.HasOne(d => d.Lin)
                    .WithMany(p => p.AppTemas)
                    .HasForeignKey(d => d.LinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEMAS_APP_LINEAS");
            });

            modelBuilder.Entity<AppTemasProyectos>(entity =>
            {
                entity.ToTable("APP_TEMAS_PROYECTOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TemId).HasColumnName("TEM_ID");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppTemasProyectos)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_TEMAS_PROYECTOS_APP_PROYECTOS");

                entity.HasOne(d => d.Tem)
                    .WithMany(p => p.AppTemasProyectos)
                    .HasForeignKey(d => d.TemId)
                    .HasConstraintName("FK_TEMAS_PROYECTOS_TEMAS");
            });

            modelBuilder.Entity<AppTipoDocumentos>(entity =>
            {
                entity.HasKey(e => e.TdoId);

                entity.ToTable("APP_TIPO_DOCUMENTOS");

                entity.Property(e => e.TdoId)
                    .HasColumnName("TDO_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.TdoNombre)
                    .HasColumnName("TDO_NOMBRE")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.TdoObservacion)
                    .HasColumnName("TDO_OBSERVACION")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AppTipoDocumentosValores>(entity =>
            {
                entity.HasKey(e => e.TdvId);

                entity.ToTable("APP_TIPO_DOCUMENTOS_VALORES");

                entity.Property(e => e.TdvId)
                    .HasColumnName("TDV_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TdoId)
                    .HasColumnName("TDO_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TdvNombre)
                    .HasColumnName("TDV_NOMBRE")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TdvNumeroPaginas).HasColumnName("TDV_NUMERO_PAGINAS");

                entity.Property(e => e.TdvRutaAdjunto)
                    .HasColumnName("TDV_RUTA_ADJUNTO")
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

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
                    .HasName("PK__APP_TIPO__862DD7D2208085EA");

                entity.ToTable("APP_TIPO_ENTIDAD_USUARIO");

                entity.Property(e => e.Nit)
                    .HasColumnName("NIT")
                    .HasMaxLength(50);

                entity.Property(e => e.IdVigencia)
                    .HasColumnName("ID_VIGENCIA")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdDetalleTipoEntidad).HasColumnName("ID_DETALLE_TIPO_ENTIDAD");

                entity.Property(e => e.IdTipoEntidad).HasColumnName("ID_TIPO_ENTIDAD");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

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
                entity.HasKey(e => e.TppId);

                entity.ToTable("APP_TIPO_PROYECTO_PROPONENTE");

                entity.Property(e => e.TppId).HasColumnName("TPP_ID");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.TppNit)
                    .HasColumnName("TPP_NIT")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TppTipId)
                    .HasColumnName("TPP_TIP_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.TppValor)
                    .HasColumnName("TPP_VALOR")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.TppTip)
                    .WithMany(p => p.AppTipoProyectoProponente)
                    .HasForeignKey(d => d.TppTipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_TIPO_PROYECTO_PROPONENTE_BAS_TIPOS_PROYECTOS");
            });

            modelBuilder.Entity<AppTiposEntidades>(entity =>
            {
                entity.HasKey(e => e.TipId);

                entity.ToTable("APP_TIPOS_ENTIDADES");

                entity.Property(e => e.TipId).HasColumnName("TIP_ID");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.TipNombre)
                    .IsRequired()
                    .HasColumnName("TIP_NOMBRE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipNumeroProyectos).HasColumnName("TIP_NUMERO_PROYECTOS");

                entity.Property(e => e.TipRecursosEntidad).HasColumnName("TIP_RECURSOS_ENTIDAD");

                entity.Property(e => e.TipRecursosPropios).HasColumnName("TIP_RECURSOS_PROPIOS");

                entity.Property(e => e.TipTipId)
                    .HasColumnName("TIP_TIP_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<AppTiposPuntaje>(entity =>
            {
                entity.HasKey(e => e.PunId);

                entity.ToTable("APP_TIPOS_PUNTAJE");

                entity.Property(e => e.PunId)
                    .HasColumnName("PUN_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador único para el tipo de puntaje")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.PunDescripcion)
                    .HasColumnName("PUN_DESCRIPCION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador de la vigencia.");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.AppTiposPuntaje)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VIGENCIAS_APP_PUNTAJES");
            });

            modelBuilder.Entity<AppUsuariosImpresion>(entity =>
            {
                entity.ToTable("APP_USUARIOS_IMPRESION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cuentausuarioid).HasColumnName("CUENTAUSUARIOID");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaImpresion)
                    .HasColumnName("FECHA_IMPRESION")
                    .HasColumnType("datetime");

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
                entity.HasKey(e => new { e.IndId, e.ProId });

                entity.ToTable("APP_VALORES_INDICADOR");

                entity.HasComment("Esta tabla son los valores de variable por proyecto");

                entity.Property(e => e.IndId)
                    .HasColumnName("IND_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador único del indicador");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("Identificador del proyecto");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

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
                    .HasColumnType("decimal(33, 15)")
                    .HasComment("Valor del indicador.");

                entity.Property(e => e.ValValorTexto)
                    .HasColumnName("VAL_VALOR_TEXTO")
                    .IsUnicode(false);

                entity.HasOne(d => d.Ind)
                    .WithMany(p => p.AppValoresIndicador)
                    .HasForeignKey(d => d.IndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VALORES_INDICADOR_APP_INDICADORES");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.AppValoresIndicador)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_VALORES_INDICADOR_APP_PROYECTOS");
            });

            modelBuilder.Entity<AppVariables>(entity =>
            {
                entity.HasKey(e => e.VarId);

                entity.ToTable("APP_VARIABLES");

                entity.HasComment("Esta tabla correspond a los criterios de evaluación");

                entity.Property(e => e.VarId)
                    .HasColumnName("VAR_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador de la variable.")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.LinId)
                    .HasColumnName("LIN_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PunId)
                    .HasColumnName("PUN_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador único para el tipo de puntaje");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VarDescripcion)
                    .HasColumnName("VAR_DESCRIPCION")
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasComment("Descripción de la variable");

                entity.Property(e => e.VarFormulado)
                    .HasColumnName("VAR_FORMULADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Indica si es una variable formulada");

                entity.Property(e => e.VarOperador)
                    .HasColumnName("VAR_OPERADOR")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.VarOperando1)
                    .HasColumnName("VAR_OPERANDO1")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Formula para calcular el valor de la variable");

                entity.Property(e => e.VarOperando2)
                    .HasColumnName("VAR_OPERANDO2")
                    .HasColumnType("numeric(18, 0)");

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
                entity.HasKey(e => e.VigId);

                entity.ToTable("APP_VIGENCIAS");

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Identificador de la vigencia.")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VigConsecutivo)
                    .HasColumnName("VIG_CONSECUTIVO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VigConsecutivoNac).HasColumnName("VIG_CONSECUTIVO_NAC");

                entity.Property(e => e.VigDiasExpiracionProyecto)
                    .HasColumnName("VIG_DIAS_EXPIRACION_PROYECTO")
                    .HasDefaultValueSql("((0))")
                    .HasComment("Numero de dias");

                entity.Property(e => e.VigEstado)
                    .IsRequired()
                    .HasColumnName("VIG_ESTADO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('A')")
                    .HasComment("Estado de la Vigencia. Activa (A) o Inactiva (I)");

                entity.Property(e => e.VigFechaFinal)
                    .HasColumnName("VIG_FECHA_FINAL")
                    .HasColumnType("datetime")
                    .HasComment("Fecha final de la vigencia");

                entity.Property(e => e.VigFechaInicio)
                    .HasColumnName("VIG_FECHA_INICIO")
                    .HasColumnType("datetime")
                    .HasComment("Fecha de inicio para la vigencia");

                entity.Property(e => e.VigNombre)
                    .IsRequired()
                    .HasColumnName("VIG_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre de la vigencia");

                entity.Property(e => e.VigPlazoDocumentacion)
                    .HasColumnName("VIG_PLAZO_DOCUMENTACION")
                    .HasComment("Número de días que tiene el proponente para entregar la documentación.");

                entity.Property(e => e.VigValorMaximo).HasColumnName("VIG_VALOR_MAXIMO");
            });

            modelBuilder.Entity<BasDependencias>(entity =>
            {
                entity.HasKey(e => e.DepId);

                entity.ToTable("BAS_DEPENDENCIAS");

                entity.Property(e => e.DepId)
                    .HasColumnName("DEP_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AreId)
                    .HasColumnName("ARE_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DepDireccion)
                    .HasColumnName("DEP_DIRECCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepNombre)
                    .HasColumnName("DEP_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DepTelefonos)
                    .HasColumnName("DEP_TELEFONOS")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecId)
                    .HasColumnName("SEC_ID")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<BasEntidadesFinancieras>(entity =>
            {
                entity.HasKey(e => e.EntId);

                entity.ToTable("BAS_ENTIDADES_FINANCIERAS");

                entity.Property(e => e.EntId)
                    .HasColumnName("ENT_ID")
                    .HasColumnType("decimal(18, 0)")
                    .HasComment("Identificador único de la entidad")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EntNombre)
                    .HasColumnName("ENT_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("Nombre de la entidad");

                entity.Property(e => e.EntVisible)
                    .HasColumnName("ENT_VISIBLE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BasTiposProyectos>(entity =>
            {
                entity.HasKey(e => e.TipId);

                entity.ToTable("BAS_TIPOS_PROYECTOS");

                entity.Property(e => e.TipId)
                    .HasColumnName("TIP_ID")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TipInstancia)
                    .IsRequired()
                    .HasColumnName("TIP_INSTANCIA")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipNombre)
                    .IsRequired()
                    .HasColumnName("TIP_NOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.BasTiposProyectos)
                    .HasForeignKey(d => d.VigId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BAS_TIPOS_PROYECTOS_APP_VIGENCIAS");
            });

            modelBuilder.Entity<BasZonasGeograficas>(entity =>
            {
                entity.HasKey(e => e.ZonId);

                entity.ToTable("BAS_ZONAS_GEOGRAFICAS");

                entity.Property(e => e.ZonId)
                    .HasColumnName("ZON_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZonCategoria)
                    .HasColumnName("ZON_CATEGORIA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZonDistrito).HasColumnName("ZON_DISTRITO");

                entity.Property(e => e.ZonLatitud).HasColumnName("ZON_LATITUD");

                entity.Property(e => e.ZonLongitud).HasColumnName("ZON_LONGITUD");

                entity.Property(e => e.ZonNombre)
                    .HasColumnName("ZON_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZonPadreId)
                    .HasColumnName("ZON_PADRE_ID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ZonPoblacion)
                    .HasColumnName("ZON_POBLACION")
                    .HasColumnType("numeric(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ZonPoblacionsinic)
                    .HasColumnName("ZON_POBLACIONSINIC")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Cuentausuario>(entity =>
            {
                entity.ToTable("CUENTAUSUARIO", "Seguridad");

                entity.HasComment("Almacena los usuarios del sistema");

                entity.Property(e => e.Cuentausuarioid)
                    .HasColumnName("CUENTAUSUARIOID")
                    .HasComment("Id de la tabla");

                entity.Property(e => e.Cuentausuarioclave)
                    .IsRequired()
                    .HasColumnName("CUENTAUSUARIOCLAVE")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasComment("Clave encriptada del usuario");

                entity.Property(e => e.Cuentausuariodominio)
                    .HasColumnName("CUENTAUSUARIODOMINIO")
                    .HasComment("Indica si la cuenta pertenece al LDAP");

                entity.Property(e => e.Cuentausuarioemail)
                    .IsRequired()
                    .HasColumnName("CUENTAUSUARIOEMAIL")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Email del usuario");

                entity.Property(e => e.Cuentausuariofechaactualizacionclave)
                    .HasColumnName("CUENTAUSUARIOFECHAACTUALIZACIONCLAVE")
                    .HasColumnType("datetime")
                    .HasComment("Fecha en la que actualizó la clave por última vez");

                entity.Property(e => e.Cuentausuariohabilitada)
                    .HasColumnName("CUENTAUSUARIOHABILITADA")
                    .HasComment("Estado del usuario (Activo e Inactivo)");

                entity.Property(e => e.Cuentausuariohistorialclave)
                    .HasColumnName("CUENTAUSUARIOHISTORIALCLAVE")
                    .IsUnicode(false)
                    .HasComment("Se almacenan datos relacionados con el cambio de clave");

                entity.Property(e => e.Cuentausuariolink)
                    .HasColumnName("CUENTAUSUARIOLINK")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuentausuarionumerointentos)
                    .HasColumnName("CUENTAUSUARIONUMEROINTENTOS")
                    .HasComment("Conteo del número de intentos fallidos del usuario");

                entity.Property(e => e.Cuentausuarioplazoprimerlogeo)
                    .HasColumnName("CUENTAUSUARIOPLAZOPRIMERLOGEO")
                    .HasColumnType("datetime")
                    .HasComment("Fecha en la que vence el primer logeo");

                entity.Property(e => e.Cuentausuariosesionid)
                    .HasColumnName("CUENTAUSUARIOSESIONID")
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasComment("Sessión del usuario autenticado");

                entity.Property(e => e.Cuentausuariousuario)
                    .IsRequired()
                    .HasColumnName("CUENTAUSUARIOUSUARIO")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Nombre de usuario (Único)");

                entity.Property(e => e.Cuentausuariovencimiento)
                    .HasColumnName("CUENTAUSUARIOVENCIMIENTO")
                    .HasColumnType("datetime")
                    .HasComment("Fecha en la que vence la clave");

                entity.Property(e => e.Personaid)
                    .HasColumnName("PERSONAID")
                    .HasColumnType("numeric(18, 0)")
                    .HasComment("Persona a la que pertenece el usario");
            });

            modelBuilder.Entity<EnvioCorreos>(entity =>
            {
                entity.ToTable("ENVIO_CORREOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Asunto)
                    .IsRequired()
                    .HasColumnName("ASUNTO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cuerpo)
                    .IsRequired()
                    .HasColumnName("CUERPO")
                    .IsUnicode(false);

                entity.Property(e => e.Enviado).HasColumnName("ENVIADO");

                entity.Property(e => e.FechaCreo)
                    .HasColumnName("FECHA_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaEnvio)
                    .HasColumnName("FECHA_ENVIO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Intento).HasColumnName("INTENTO");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("OBSERVACIONES")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Remitentes)
                    .IsRequired()
                    .HasColumnName("REMITENTES")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("FUNCIONARIO", "Seguridad");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("Identificador de la tabla");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasColumnName("GENERO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("Genero M, F");

                entity.Property(e => e.Nombrecompleto)
                    .HasColumnName("NOMBRECOMPLETO")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("Nombre completo de la persona");

                entity.Property(e => e.Numeroid)
                    .IsRequired()
                    .HasColumnName("NUMEROID")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("Número de identificación de la persona");

                entity.Property(e => e.Primerapellido)
                    .IsRequired()
                    .HasColumnName("PRIMERAPELLIDO")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Primer apellido de la persona");

                entity.Property(e => e.Primernombre)
                    .HasColumnName("PRIMERNOMBRE")
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasComment("Primer nombre de la persona");

                entity.Property(e => e.Segundoapellido)
                    .HasColumnName("SEGUNDOAPELLIDO")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Segundo apellido de la persona");

                entity.Property(e => e.Segundonombre)
                    .HasColumnName("SEGUNDONOMBRE")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Segundo nombre de la persona");

                entity.Property(e => e.Tipoidentificacionid)
                    .HasColumnName("TIPOIDENTIFICACIONID")
                    .HasComment("Tipo de identificación de la persona, 1 = CC");
            });

            modelBuilder.Entity<Logacciones>(entity =>
            {
                entity.HasKey(e => e.Logid);

                entity.ToTable("LOGACCIONES", "Seguridad");

                entity.Property(e => e.Logid).HasColumnName("LOGID");

                entity.Property(e => e.Logfecha)
                    .HasColumnName("LOGFECHA")
                    .HasColumnType("datetime");

                entity.Property(e => e.Logip)
                    .IsRequired()
                    .HasColumnName("LOGIP")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logkey)
                    .IsRequired()
                    .HasColumnName("LOGKEY")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logtipoaccion)
                    .IsRequired()
                    .HasColumnName("LOGTIPOACCION")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Logtraza)
                    .IsRequired()
                    .HasColumnName("LOGTRAZA")
                    .IsUnicode(false);

                entity.Property(e => e.Logusuario)
                    .IsRequired()
                    .HasColumnName("LOGUSUARIO")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("PERFIL", "Seguridad");

                entity.HasComment("ALMACENA LOS PERFILES DE LAS CUENTAS DE USUARIO");

                entity.HasIndex(e => e.Perfilnombre)
                    .HasName("UIX_PERFIL")
                    .IsUnique();

                entity.Property(e => e.Perfilid)
                    .HasColumnName("PERFILID")
                    .HasComment("IDENTIFICADOR DEL PERFIL");

                entity.Property(e => e.Perfilhabilitado)
                    .HasColumnName("PERFILHABILITADO")
                    .HasComment("INDICADOR (1)HABILITADO (0)DESHABILITADO");

                entity.Property(e => e.Perfilnombre)
                    .IsRequired()
                    .HasColumnName("PERFILNOMBRE")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("NOMBRE DEL PERFIL");

                entity.Property(e => e.Perfiltipo)
                    .IsRequired()
                    .HasColumnName("PERFILTIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("TIPO DEL PERFIL (I)NTERNO, (E)XTERNO");
            });

            modelBuilder.Entity<PerfilesCuentausuario>(entity =>
            {
                entity.ToTable("PERFILES_CUENTAUSUARIO", "Seguridad");

                entity.HasComment("Almacena los perfiles asociados a las cuentas de usuario");

                entity.HasIndex(e => new { e.Perfilid, e.Cuentausuarioid })
                    .HasName("UIX_PERFILES_CUENTAUSUARIO")
                    .IsUnique();

                entity.Property(e => e.PerfilesCuentausuarioid)
                    .HasColumnName("PERFILES_CUENTAUSUARIOID")
                    .HasComment("Identificador de la relacion del perfil y la cuenta de usuario");

                entity.Property(e => e.Cuentausuarioid)
                    .HasColumnName("CUENTAUSUARIOID")
                    .HasComment("Identificador de la cuenta de usuario");

                entity.Property(e => e.Perfilid)
                    .HasColumnName("PERFILID")
                    .HasComment("Identificador del perfil");

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

                entity.ToTable("PLANTILLA_CORREOS");

                entity.Property(e => e.Codigoplantillacorreos)
                    .HasColumnName("CODIGOPLANTILLACORREOS")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Asunto)
                    .IsRequired()
                    .HasColumnName("ASUNTO")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cuerpo)
                    .IsRequired()
                    .HasColumnName("CUERPO")
                    .IsUnicode(false);

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PreguntaSeguridad>(entity =>
            {
                entity.ToTable("PREGUNTA_SEGURIDAD", "Seguridad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Pregunta)
                    .IsRequired()
                    .HasColumnName("PREGUNTA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PreguntaUsuario>(entity =>
            {
                entity.ToTable("PREGUNTA_USUARIO", "Seguridad");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cuentausuarioid).HasColumnName("CUENTAUSUARIOID");

                entity.Property(e => e.Estado).HasColumnName("ESTADO");

                entity.Property(e => e.FecCreo)
                    .HasColumnName("FEC_CREO")
                    .HasColumnType("datetime");

                entity.Property(e => e.FecModifico)
                    .HasColumnName("FEC_MODIFICO")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idpregunta).HasColumnName("IDPREGUNTA");

                entity.Property(e => e.Respuesta)
                    .IsRequired()
                    .HasColumnName("RESPUESTA")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuCreo)
                    .IsRequired()
                    .HasColumnName("USU_CREO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuModifico)
                    .HasColumnName("USU_MODIFICO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

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

            modelBuilder.Entity<PresupuestoParametrizacionLineasTope>(entity =>
            {
                entity.HasKey(e => e.PplId);

                entity.ToTable("PRESUPUESTO_PARAMETRIZACION_LINEAS_TOPE");

                entity.Property(e => e.PplId).HasColumnName("PPL_ID");

                entity.Property(e => e.LinId)
                    .HasColumnName("LIN_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ValorTopePresupuesto)
                    .HasColumnName("VALOR_TOPE_PRESUPUESTO")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ZonId)
                    .HasColumnName("ZON_ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lin)
                    .WithMany(p => p.PresupuestoParametrizacionLineasTope)
                    .HasForeignKey(d => d.LinId)
                    .HasConstraintName("FK_PRESUPUESTO_PARAMETRIZACION_LINEAS_TOPE_PRESUPUESTO_PARAMETRIZACION_LINEAS_TOPE");

                entity.HasOne(d => d.Zon)
                    .WithMany(p => p.PresupuestoParametrizacionLineasTope)
                    .HasForeignKey(d => d.ZonId)
                    .HasConstraintName("FK_PRESUPUESTO_PARAMETRIZACION_LINEAS_TOPE_BAS_ZONAS_GEOGRAFICAS");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("SERVICIO", "Seguridad");

                entity.HasComment("ALMACENA LOS SERVICIOS DEL SISTEMA");

                entity.HasIndex(e => e.Servicionombre)
                    .HasName("UIX_SERVICIO")
                    .IsUnique();

                entity.Property(e => e.Servicioid)
                    .HasColumnName("SERVICIOID")
                    .HasComment("IDENTIFICADOR DEL SERVICIO")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Servicioactivo)
                    .HasColumnName("SERVICIOACTIVO")
                    .HasComment("INDICADOR (1)ACTIVO EN MENÚ, (0)NO ACTIVO EN MENÚ");

                entity.Property(e => e.Serviciohabilitado)
                    .HasColumnName("SERVICIOHABILITADO")
                    .HasComment("INDICADOR (1)HABILITADO, (0)NO HABILITADO");

                entity.Property(e => e.Servicioicono)
                    .HasColumnName("SERVICIOICONO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Serviciojerarquia)
                    .IsRequired()
                    .HasColumnName("SERVICIOJERARQUIA")
                    .HasComment("JERARQUIA DEL SERVICIO");

                entity.Property(e => e.Servicionivel)
                    .HasColumnName("SERVICIONIVEL")
                    .HasComment("NIVEL DEL SERVICIO")
                    .HasComputedColumnSql("([SERVICIOJERARQUIA].[GetLevel]())");

                entity.Property(e => e.Servicionombre)
                    .IsRequired()
                    .HasColumnName("SERVICIONOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("NOMBRE DEL SERVICIO");

                entity.Property(e => e.Servicioreferenciareporte)
                    .HasColumnName("SERVICIOREFERENCIAREPORTE")
                    .HasComment("INDICADOR (1)REFERENCIA REPORTE (0)NO REFERENCIA REPORTE");

                entity.Property(e => e.Serviciotipo)
                    .IsRequired()
                    .HasColumnName("SERVICIOTIPO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("INDICA SI EL SERVICIO ES (P)UBLICO O P(R)IVADO");

                entity.Property(e => e.Serviciovista)
                    .IsRequired()
                    .HasColumnName("SERVICIOVISTA")
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasComment("RUTA DONDE SE ENCUENTRA LA VISTA ASOCIADA A LA CAPA DE PRESENTACION (WEB)");
            });

            modelBuilder.Entity<ServiciosPerfil>(entity =>
            {
                entity.ToTable("SERVICIOS_PERFIL", "Seguridad");

                entity.HasComment("Almacena los servicios asociados a los perfiles");

                entity.HasIndex(e => new { e.Servicioid, e.Perfilid })
                    .HasName("UIX_SERVICIOS_PERFIL")
                    .IsUnique();

                entity.Property(e => e.ServiciosPerfilid)
                    .HasColumnName("SERVICIOS_PERFILID")
                    .HasComment("Identificador de la relacion del servicio y el perfil");

                entity.Property(e => e.Perfilid)
                    .HasColumnName("PERFILID")
                    .HasComment("Identificador del perfil");

                entity.Property(e => e.Servicioid)
                    .HasColumnName("SERVICIOID")
                    .HasComment("Identificador del servicio");

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

            modelBuilder.Entity<TipoTrayectoria>(entity =>
            {
                entity.HasKey(e => e.TtrId);

                entity.ToTable("TIPO_TRAYECTORIA");

                entity.Property(e => e.TtrId)
                    .HasColumnName("TTR_ID")
                    .HasComment("IDTIPOTRAYECTORIA");

                entity.Property(e => e.TtrActivo).HasColumnName("TTR_ACTIVO");

                entity.Property(e => e.TtrNombre)
                    .HasColumnName("TTR_NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("NOMBRETIPOTRAYECTORIA");
            });

            modelBuilder.Entity<Trayectoria>(entity =>
            {
                entity.HasKey(e => e.TraId);

                entity.ToTable("TRAYECTORIA");

                entity.Property(e => e.TraId).HasColumnName("TRA_ID");

                entity.Property(e => e.TraPregunta).HasColumnName("TRA_PREGUNTA");

                entity.Property(e => e.TtrId).HasColumnName("TTR_ID");

                entity.Property(e => e.VigId)
                    .HasColumnName("VIG_ID")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Vig)
                    .WithMany(p => p.Trayectoria)
                    .HasForeignKey(d => d.VigId)
                    .HasConstraintName("FK_TRAYECTORIA_TIPO_TRAYECTORIA");
            });

            modelBuilder.Entity<TrayectoriaProyecto>(entity =>
            {
                entity.HasKey(e => e.TprId);

                entity.ToTable("TRAYECTORIA_PROYECTO");

                entity.Property(e => e.TprId).HasColumnName("TPR_ID");

                entity.Property(e => e.ProId)
                    .HasColumnName("PRO_ID")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TprFechainsercion)
                    .HasColumnName("TPR_FECHAINSERCION")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TprRespuestaTrayectoria).HasColumnName("TPR_RESPUESTA_TRAYECTORIA");

                entity.Property(e => e.TraId).HasColumnName("TRA_ID");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.TrayectoriaProyecto)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK_TRAYECTORIA_PROYECTO_TRAYECTORIA_PROYECTO");

                entity.HasOne(d => d.Tra)
                    .WithMany(p => p.TrayectoriaProyecto)
                    .HasForeignKey(d => d.TraId)
                    .HasConstraintName("FK_TRAYECTORIA_PROYECTO_TRAYECTORIA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
