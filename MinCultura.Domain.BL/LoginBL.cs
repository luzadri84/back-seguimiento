using System;
using System.Linq;
using System.Text.Json;
using AutoMapper;
using MinCultura.Domain.BL.Interface;
using MinCultura.Domain.Common;
using MinCultura.Domain.Common.DTO;
using MinCultura.Domain.Common.Exceptions;
using MinCultura.Domain.DAL.Models;
using MinCultura.Domain.DAL.Repository.Base;
using MinCultura.Domain.DAL.Repository.Interface;
using Microsoft.Extensions.Configuration;
using MinCultura.Domain.DAL.Context;
using System.Collections.ObjectModel;

namespace MinCultura.Domain.BL
{
    public class LoginBL : BaseBL, ILoginBL
    {
        private readonly ICuentausuarioRepository<Cuentausuario> _usuarioRepository;
        private readonly BaseRepository<Perfil> _perfilRepository;
        private readonly BaseRepository<AppTipoProyectoProponente> _tipoProyProponentRepository;
        private readonly IAppProponentesRepository<AppProponentes> _appProponentesRepositor;
        private readonly ICuentausuarioRepository<Cuentausuario> _cuentausuarioRepository;
        private readonly BaseRepository<PerfilesCuentausuario> _perfilCuentaUsuarioRepository;
        private readonly BaseRepository<PlantillaCorreos> _plantillaCorreosRepository;
        private readonly BaseRepository<EnvioCorreos> _envioCorreosRepository;
        private readonly BaseRepository<Funcionario> _funcionarioRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ConcertacionContext _context;

        public LoginBL(ICuentausuarioRepository<Cuentausuario> usuarioRepository,
            BaseRepository<Perfil> perfilRepository,
            BaseRepository<AppTipoProyectoProponente> tipoProyProponentRepository,
            IAppProponentesRepository<AppProponentes> appProponentesRepositor,
            ICuentausuarioRepository<Cuentausuario> cuentausuarioRepository,
            BaseRepository<PerfilesCuentausuario> perfilCuentaUsuarioRepository,
            BaseRepository<PlantillaCorreos> plantillaCorreosRepository,
            BaseRepository<EnvioCorreos> envioCorreosRepository,
            BaseRepository<Funcionario> funcionarioRepository,
        IMapper mapper,
            IConfiguration configuration,
            ConcertacionContext context)
        {
            _usuarioRepository = usuarioRepository;
            _perfilRepository = perfilRepository;
            _tipoProyProponentRepository = tipoProyProponentRepository;
            _appProponentesRepositor = appProponentesRepositor;
            _cuentausuarioRepository = cuentausuarioRepository;
            _perfilCuentaUsuarioRepository = perfilCuentaUsuarioRepository;
            _plantillaCorreosRepository = plantillaCorreosRepository;
            _envioCorreosRepository = envioCorreosRepository;
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
            _configuration = configuration;
            _context = context;
        }

        /// <summary>
        /// Método para actualizar un usuario y asociarlo a una Entidad
        /// </summary>
        /// <param name="usuario">Información del usuario a actualizar</param>
        /// <returns>Respuesta Usuario actualizado si cumple con los requisitos de la convocatoria</returns>
        public bool ActualizarUsuario(CuentaUsuarioDto actualizar)
        {
            bool actualizado = false;
            try
            {
                var usuarioAct = _usuarioRepository.Get(p => p.Cuentausuariousuario.ToLower().Equals(actualizar.Cuentausuariousuario)).FirstOrDefault();

                var existeCorreo = _usuarioRepository.Get(p => !p.Cuentausuariousuario.ToLower().Equals(actualizar.Cuentausuariousuario)
                    && p.Cuentausuarioemail.Equals(actualizar.Cuentausuarioemailnuevoconf) && p.Cuentausuariohabilitada).FirstOrDefault();

                if (existeCorreo != null)
                    return false;

                //Actualizó cuanta usuario
                usuarioAct.Cuentausuarioemail = actualizar.Cuentausuarioemailnuevoconf;
                _cuentausuarioRepository.Update(usuarioAct);

                //Actualizo el correo del proponenten
                var proponente = _appProponentesRepositor.Get(p => p.ProId.Equals(usuarioAct.Personaid)).FirstOrDefault();
                if(proponente != null)
                {
                    proponente.ProCorreoElectronicoRepresentanteLegal = actualizar.Cuentausuarioemailnuevoconf;
                    _appProponentesRepositor.Update(proponente);
                }

                actualizado = true;
            }
            catch(Exception ex)
            {
                DebugLog($"Error al actualizar el usuario, detalle del error: {ex.Message}");
            }
            return actualizado;
        }

        /// <summary>
        /// Registrar un usuario externos asociado a una entidad
        /// </summary>
        /// <param name="crear"></param>
        /// <returns></returns>
        public CrearUsuarioRespuestaDto CrearUsuario(CrearUsuarioDto crear)
        {
            bool creado = false;
            string mensaje = string.Empty, body_replace = string.Empty;
            AppProponentes proponente = null;
            using (var transaction = _context.Database.BeginTransaction())
            { 
                try
                {
                    //1 Validar que no exista el nombre de usuario
                    var existeNombreUsuario = _cuentausuarioRepository.Get(p => (p.Cuentausuariousuario.ToLower().Equals(crear.NombreUsuario.ToLower()) ||
                        p.Cuentausuarioemail.ToLower().Equals(crear.Correo.ToLower())) && p.Cuentausuariohabilitada).FirstOrDefault();
                    if (existeNombreUsuario != null)
                    {
                        mensaje = $"Ya existe un usuario registrado con el nombre o correo ingresado.";
                    }
                    else
                    {
                        //1.1 Validar si ya existe el usuario
                        proponente = _appProponentesRepositor.Get(p => p.ProNit.Equals(crear.Nit)).FirstOrDefault();
                        if (proponente != null)
                        {
                            var existeUsuario = _cuentausuarioRepository.Get(p => p.Personaid == proponente.ProId && p.Cuentausuariohabilitada).FirstOrDefault();
                            if (existeUsuario != null)
                                mensaje = $"Ya existe el usuario registrado con el correo: {existeUsuario.Cuentausuarioemail}";
                        }
                    }
                    if (string.IsNullOrEmpty(mensaje))
                    {
                        //2. Validar si esta en la tabla: APP_TIPO_PROYECTO_PROPONENTE, de acuerdo a los NIT restringidos.
                        var blackList = _tipoProyProponentRepository.Get(p => p.TppNit.Equals(crear.Nit) && p.TppTipId == crear.TipoEntidad).FirstOrDefault();
                        if (blackList != null)
                        {
                            mensaje = "El NIT no está autorizado para inscribirse en la convocatoria.";
                        }
                        else
                        {
                            //var nombreUsuario = crear.Correo.Split('@')[0];
                            //3. Crear registro en la tabla: APP_TIPO_ENTIDAD_USUARIO


                            //4. Crear registro en la tabla: APP_PROPONENTES
                            int idProponent;
                            if (proponente == null)
                            {

                                idProponent = (int)_appProponentesRepositor.Create(new AppProponentes()
                                {
                                    ProNit = crear.Nit,
                                    TipId = crear.TipIdEntidad,
                                    ProCorreoElectronicoRepresentanteLegal = crear.Correo,
                                    UsuCreo = crear.NombreUsuario,
                                    FecCreo = DateTime.Now
                                });
                            }
                            else
                            {
                                idProponent = (int)proponente.ProId;
                            }
                            string guid = Guid.NewGuid().ToString();
                            //5. Crear registro en la tabla: Seguridad.CUENTAUSUARIO
                            int cuentausuarioid = (int)_cuentausuarioRepository.Create(new Cuentausuario()
                            {
                                Personaid = idProponent,
                                Cuentausuariousuario = crear.NombreUsuario,
                                Cuentausuariodominio = false,
                                Cuentausuarioclave = Encrypt.GetSHA256(crear.Contrasena),
                                Cuentausuarioemail = crear.Correo,
                                Cuentausuarionumerointentos = 0,
                                Cuentausuariohabilitada = false,
                                Cuentausuariolink = guid,
                            });
                            //6. Asociar rol al usuario
                            _perfilCuentaUsuarioRepository.Create(new PerfilesCuentausuario()
                            {
                                Perfilid = 2,
                                Cuentausuarioid = cuentausuarioid
                            });
                            //7. Obtengo la plantilla del correo y remplazo las variables dinámicas (Usuario, enlace, etc).
                            var plantilla = _plantillaCorreosRepository.Get(p => p.Codigoplantillacorreos.Equals("002")).FirstOrDefault();
                            if (plantilla == null)
                            {
                                DebugLog("Error al crear el usuario, no está configurada la plantilla de envío de correos para confirmar el usuario.");
                                mensaje = "Error al crear el usuario.";
                                creado = false;
                            }
                            else
                            {
                                var body = plantilla.Cuerpo;
                                var link = _configuration.GetSection("linkSite").Value + "confirm?guid=" + guid;
                                body_replace = body.Replace("{NOMBRE_USUARIO}", crear.NombreUsuario).Replace("{LINK}", link);
                                //8. Guardo la notificación en la tabla de ENVIO_CORREOS para que el worker de envío de correo lo procese posteriormente.
                                _envioCorreosRepository.Create(new EnvioCorreos()
                                {
                                    Asunto = plantilla.Asunto,
                                    Cuerpo = body_replace,
                                    Remitentes = crear.Correo,
                                    Enviado = false,
                                    Intento = 0,
                                    FechaCreo = DateTime.Now
                                });
                                mensaje = "Usuario creado correctamente.";
                                creado = true;
                                transaction.Commit();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    DebugLog($"Error al crear el usuario. Error: {ex.Message}");
                    creado = false;
                    mensaje = "Error al crear el usuario.";
                }
            }   
            return new CrearUsuarioRespuestaDto() { Resultado = creado, Mensaje = mensaje };
        }

        /// <summary>
        /// Realizar el proceso de autenticación del usuario
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public CuentaUsuarioDto Login(UserLoginDto login)
        {
            CuentaUsuarioDto _cuentaUsuarioDto = new CuentaUsuarioDto();

            var usuario = _usuarioRepository.Get(p => p.Cuentausuariousuario.ToLower().Equals(login.Usuario.ToLower())).FirstOrDefault();

            if (usuario == null)
            {
                InfoLog($"Intento de login fallido, usuario no existe: {login.Usuario}");
                throw new UserNotFoundException("La clave o usuario no coinciden.");
            }
            if (!usuario.Cuentausuariohabilitada)
            {
                InfoLog($"Usuario inactivo: {login.Usuario}");
                throw new UserDisabledException("La clave o usuario no coinciden.");
            }

            var isValid = CheckPassword(usuario.Cuentausuarioclave, login.Password);
            if (!isValid)
            {
                InfoLog($"Intento de login fallido del usuario {login.Usuario}");
                //CheckAccesFailedCount(usuario);
                throw new PasswordFailedException("La clave o usuario no coinciden.");
            }
            //Asignar el perfil del usuario
            foreach (var item in usuario.PerfilesCuentausuario)
            {
                item.Perfil = _perfilRepository.Get(p => p.Perfilid == item.Perfilid).FirstOrDefault();
            }
            _cuentaUsuarioDto = _mapper.Map<CuentaUsuarioDto>(usuario);

            InfoLog($"Authentication succeeded: {JsonSerializer.Serialize(_cuentaUsuarioDto, SerializerOptions.options)}");

            return _cuentaUsuarioDto;
        }

        /// <summary>
        /// Método para solocitar la recuperación de la clave de un usuario
        /// </summary>
        /// </summary>
        /// <param name="usuario">Información del usuario que desea recuperar la clave</param>
        /// <returns>Respuesta positiva si logró realizar el proceso de recuperación del correo electrónico y false en caso contrario</returns>
        public RespuestaDto RecuperarClave(ForgotDto usuario)
        {
            RespuestaDto respuesta = new RespuestaDto();
            bool recupero = false;
            string Mensaje = "OK", body_replace = string.Empty;
            Cuentausuario cuentausuario = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(usuario.usuario))
                    cuentausuario = _usuarioRepository.Get(p => p.Cuentausuariousuario.ToLower().Equals(usuario.usuario.ToLower()) && p.Cuentausuariohabilitada).FirstOrDefault();
                else if (!string.IsNullOrWhiteSpace(usuario.correo))
                    cuentausuario = _usuarioRepository.Get(p => p.Cuentausuarioemail.ToLower().Equals(usuario.correo.ToLower()) && p.Cuentausuariohabilitada).FirstOrDefault();

                if (cuentausuario == null)
                {
                    recupero = false;
                    Mensaje = "Usuario o correo electrónico errado.";
                }
                else
                {
                    //1. Genero un Guid que formará parte de la URL para realizar el cambio de contraseña y adicionalmente estableceré
                    //La fecha actual + 4 horas para poder realizar el cambio, posterior a esa hora el enlace quedará caducado.
                    cuentausuario.Cuentausuariolink = Guid.NewGuid().ToString();
                    cuentausuario.Cuentausuarioplazoprimerlogeo = DateTime.Now.AddHours(4);
                    _usuarioRepository.Update(cuentausuario);

                    //2. Obtengo la plantilla del correo y remplazo las variables dinámicas (Usuario, enlace, etc).
                    var plantilla = _plantillaCorreosRepository.Get(p => p.Codigoplantillacorreos.Equals("001")).FirstOrDefault();
                    if(plantilla == null)
                    {
                        DebugLog("Error al recuperar la clave del usuario, no está configurada la plantilla de envío de correos");
                        recupero = false;
                        Mensaje = "Usuario o correo electrónico errado.";
                    }
                    else
                    {
                        string body = plantilla.Cuerpo;
                        var link = _configuration.GetSection("linkSite").Value + "newpasscode?guid=" + cuentausuario.Cuentausuariolink;
                        body_replace = body.Replace("{NOMBRE_USUARIO}", cuentausuario.Cuentausuariousuario).Replace("{LINK}", link);
                    }

                    //3. Guardo la notificación en la tabla de ENVIO_CORREOS para que el worker de envío de correo lo procese posteriormente.
                    _envioCorreosRepository.Create(new EnvioCorreos()
                    {
                        Asunto = plantilla.Asunto,
                        Cuerpo = body_replace,
                        Remitentes = cuentausuario.Cuentausuarioemail,
                        Enviado = false,
                        Intento = 0,
                        FechaCreo = DateTime.Now
                    });
                    recupero = true;
                    Mensaje = cuentausuario.Cuentausuarioemail;
                }
            }
            catch (Exception ex)
            {
                recupero = false;
                Mensaje = $"Error al recuperar la clave del usuario, detalle del error: {ex.Message}";
                DebugLog($"Error al recuperar la clave del usuario, detalle del error: {ex.Message}");
            }
            respuesta.Resultado = recupero;
            respuesta.Mensaje = Mensaje;
            return respuesta;
        }

        /// <summary>
        /// Valida si el enlace envíado para cambiar la contraseña es valido y no ha caducado
        /// </summary>
        /// <param name="guid">Número único de identificación de la solicitud de cambio de clave</param>
        /// <returns>True si es valido</returns>
        public RespuestaDto ValidarLink(string guid)
        {
            RespuestaDto respuesta = new RespuestaDto();
            bool linkValido = false;
            string Mensaje = "OK";
            Cuentausuario cuentausuario = null;
            try
            {
                cuentausuario = _usuarioRepository.Get(p => p.Cuentausuariolink.ToLower().Equals(guid.ToLower()) && p.Cuentausuariohabilitada).FirstOrDefault();
                if (cuentausuario == null || cuentausuario.Cuentausuarioplazoprimerlogeo == null)
                {
                    linkValido = false;
                    Mensaje = "Enlace no válido para realizar el cambio de contraseña.";
                    DebugLog($"Enlace no válido para realizar el cambio de contraseña, link errado: {guid}");
                }
                else
                {
                    DateTime fecha = Convert.ToDateTime(cuentausuario.Cuentausuarioplazoprimerlogeo);
                    if(fecha >= DateTime.Now)
                    {
                        linkValido = true;
                        Mensaje = "Enlace válido.";
                    }
                    else
                    {
                        linkValido = false;
                        Mensaje = "Enlace no válido para realizar el cambio de contraseña.";
                        DebugLog($"Enlace no válido para realizar el cambio de contraseña, la fecha cadudo: {fecha:yyyy/MM/dd HH:mm:ss}, usuario: {cuentausuario.Cuentausuariousuario}");
                    }
                }
            }
            catch (Exception ex)
            {
                linkValido = false;
                Mensaje = $"Error al validar el enlace, detalle del error: {ex.Message}";
                DebugLog($"Error al validar el enlace, detalle del error: {ex.Message}");
            }
            respuesta.Resultado = linkValido;
            respuesta.Mensaje = Mensaje;
            return respuesta;
        }

        /// <summary>
        /// Valida si el enlace envíado para confirmar el usuario es valido
        /// </summary>
        /// <param name="guid">Número único de identificación de la solicitud de confirmación del usuario</param>
        /// <returns>True si es valido</returns>
        public RespuestaDto ConfirmarUsuario(string guid)
        {
            RespuestaDto respuesta = new RespuestaDto();
            bool linkValido = false;
            string Mensaje = "OK";
            Cuentausuario cuentausuario = null;
            try
            {
                cuentausuario = _usuarioRepository.Get(p => p.Cuentausuariolink.ToLower().Equals(guid.ToLower()) && !p.Cuentausuariohabilitada).FirstOrDefault();
                if (cuentausuario == null)
                {
                    linkValido = false;
                    Mensaje = "Enlace no válido para realizar la confirmación del usuario.";
                    DebugLog($"Enlace no válido para realizar la confirmación del usuario, link errado: {guid}");
                }
                else
                {
                    cuentausuario.Cuentausuariohabilitada = true;
                    cuentausuario.Cuentausuariolink = null;
                    _usuarioRepository.Update(cuentausuario);
                    linkValido = true;
                    Mensaje = "Enlace válido.";
                }
            }
            catch (Exception ex)
            {
                linkValido = false;
                Mensaje = $"Error al validar el enlace, detalle del error: {ex.Message}";
                DebugLog($"Error al validar el enlace, detalle del error: {ex.Message}");
            }
            respuesta.Resultado = linkValido;
            respuesta.Mensaje = Mensaje;
            return respuesta;
        }

        /// <summary>
        /// Cambiar la contraseña de un usuario
        /// </summary>
        /// <param name="data">Datos requeridos para el cambio de clave</param>
        /// <returns>True si el proceso se realizó correctamente</returns>
        public RespuestaDto CambiarClave(ChangePasswordDto data)
        {
            RespuestaDto respuesta = new RespuestaDto();
            bool cambio = false;
            string Mensaje = "OK";
            Cuentausuario cuentausuario = null;
            try
            {
                cuentausuario = _usuarioRepository.Get(p => p.Cuentausuariolink.ToLower().Equals(data.guid.ToLower()) && p.Cuentausuariohabilitada).FirstOrDefault();
                if (cuentausuario == null )
                {
                    cambio = false;
                    Mensaje = "Enlace no válido para realizar el cambio de contraseña.";
                    DebugLog($"Enlace no válido para realizar el cambio de contraseña, link errado: {data.guid}, usuario: {cuentausuario.Cuentausuariousuario}");
                }
                else
                {
                    cuentausuario.Cuentausuarioclave = Encrypt.GetSHA256(data.clave);
                    cuentausuario.Cuentausuariolink = null;
                    cuentausuario.Cuentausuarioplazoprimerlogeo = null;
                    cuentausuario.Cuentausuariofechaactualizacionclave = DateTime.Now;
                    _usuarioRepository.Update(cuentausuario);
                    cambio = true;
                    Mensaje = "Cambio realizado correctamente!";
                }
            }
            catch (Exception ex)
            {
                cambio = false;
                Mensaje = $"Error al cambiar la clave, detalle del error: {ex.Message}";
                DebugLog($"Error al cambiar la clave, detalle del error: {ex.Message}");
            }
            respuesta.Resultado = cambio;
            respuesta.Mensaje = Mensaje;
            return respuesta;
        }


        /// <summary>
        /// Envio el correo de los documentos
        /// </summary>
        /// <param name="crear"></param>
        /// <returns></returns>
        public RespuestaDto EnviarCorreo(ForgotDto usuario)
        {
            RespuestaDto respuesta = new RespuestaDto();
            bool recupero = false;
            string Mensaje = "OK", body_replace = string.Empty;
            Cuentausuario cuentausuario = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(usuario.usuario))
                    cuentausuario = _usuarioRepository.Get(p => p.Cuentausuariousuario.ToLower().Equals(usuario.usuario.ToLower()) && p.Cuentausuariohabilitada).FirstOrDefault();
                else if (!string.IsNullOrWhiteSpace(usuario.correo))
                    cuentausuario = _usuarioRepository.Get(p => p.Cuentausuarioemail.ToLower().Equals(usuario.correo.ToLower()) && p.Cuentausuariohabilitada).FirstOrDefault();

                if (cuentausuario == null)
                {
                    recupero = false;
                    Mensaje = "Usuario o correo electrónico errado.";
                }
                else
                {
                    //1. Genero un Guid que formará parte de la URL para realizar el cambio de contraseña y adicionalmente estableceré
                    //La fecha actual + 4 horas para poder realizar el cambio, posterior a esa hora el enlace quedará caducado.
                    cuentausuario.Cuentausuariolink = Guid.NewGuid().ToString();
                    cuentausuario.Cuentausuarioplazoprimerlogeo = DateTime.Now.AddHours(4);
                    _usuarioRepository.Update(cuentausuario);

                    //2. Obtengo la plantilla del correo y remplazo las variables dinámicas (Usuario, enlace, etc).
                    var plantilla = _plantillaCorreosRepository.Get(p => p.Codigoplantillacorreos.Equals("001")).FirstOrDefault();
                    if (plantilla == null)
                    {
                        DebugLog("Error al recuperar la clave del usuario, no está configurada la plantilla de envío de correos");
                        recupero = false;
                        Mensaje = "Usuario o correo electrónico errado.";
                    }
                    else
                    {
                        string body = plantilla.Cuerpo;
                        var link = _configuration.GetSection("linkSite").Value + "newpasscode?guid=" + cuentausuario.Cuentausuariolink;
                        body_replace = body.Replace("{NOMBRE_USUARIO}", cuentausuario.Cuentausuariousuario).Replace("{LINK}", link);
                    }

                    //3. Guardo la notificación en la tabla de ENVIO_CORREOS para que el worker de envío de correo lo procese posteriormente.
                    _envioCorreosRepository.Create(new EnvioCorreos()
                    {
                        Asunto = plantilla.Asunto,
                        Cuerpo = body_replace,
                        Remitentes = cuentausuario.Cuentausuarioemail,
                        Enviado = false,
                        Intento = 0,
                        FechaCreo = DateTime.Now
                    });
                    recupero = true;
                    Mensaje = cuentausuario.Cuentausuarioemail;
                }
            }
            catch (Exception ex)
            {
                recupero = false;
                Mensaje = $"Error al recuperar la clave del usuario, detalle del error: {ex.Message}";
                DebugLog($"Error al recuperar la clave del usuario, detalle del error: {ex.Message}");
            }
            respuesta.Resultado = recupero;
            respuesta.Mensaje = Mensaje;
            return respuesta;
        }

        /// <summary>
        /// Lista Usuarios por perfil
        /// </summary>
        /// <param name="crear"></param>
        /// <returns></returns>
        public Collection<FuncionarioDto> getFuncionarios(int idPerfil)
        {
            Collection<PerfilesCuentausuarioDto> consulta1 = _mapper.Map<Collection<PerfilesCuentausuarioDto>>(_perfilCuentaUsuarioRepository.Get(p => p.Perfilid == idPerfil));
            //Collection<CuentaUsuarioDto> consulta2 = _mapper.Map<Collection<CuentaUsuarioDto>>(_cuentausuarioRepository.Get());
            //Collection<FuncionarioDto> consulta3 = _mapper.Map<Collection<FuncionarioDto>>(_funcionarioRepository.Get());
            Collection<FuncionarioDto> listaFuncionarios = new Collection<FuncionarioDto>();


            var resultado = from ru in consulta1
                            join ti in _mapper.Map<Collection<CuentaUsuarioDto>>(_cuentausuarioRepository.Get()) on ru.Cuentausuarioid equals ti.Cuentausuarioid
                            join fu in _mapper.Map<Collection<FuncionarioDto>>(_funcionarioRepository.Get()) on ti.Personaid equals fu.Id
                            select new
                            {
                                fu.Id, fu.Nombrecompleto
                            };


            FuncionarioDto funcionario;

            foreach (var item in resultado)
            {
                funcionario = new FuncionarioDto
                {
                    Id = item.Id,
                    Nombrecompleto = item.Nombrecompleto

                };

                listaFuncionarios.Add(funcionario);
            }


            return listaFuncionarios;
        }


        /// <summary>
        /// Metodo privado para validar el password
        /// </summary>
        /// <param name="hash">Password hash</param>
        /// <param name="password">Pasdword normal</param>
        /// <returns></returns>
        private bool CheckPassword(string hash, string password)
        {
            //Pasar pass a GetSHA256
            var passwordHash = Encrypt.GetSHA256(password);
            if (hash.Equals(passwordHash))
                return true;
            return false;
        }
              

    }
}
