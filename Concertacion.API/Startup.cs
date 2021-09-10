using System;
using System.IO;
using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MinCultura.Domain.Service;
using MinCultura.Domain.Service.Interface;
using Newtonsoft.Json;

namespace Concertacion.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                //options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            //Service
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<IAdministracionService, AdministracionService>();
            services.AddScoped<IFormulariosServicice, FormulariosService>();
            services.AddScoped<ITrayectoriaProyectoService, TrayectoriaProyectoService>();
            services.AddScoped<IEnvioProyectoService, EnvioProyectoService>();
            services.AddScoped<IEvaluacionService, EvaluacionService>();
            


            StartupService.ConfigureServices(services, connectionString);

            //JWT para generar el token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JWT:VALID_ISSUER"],
                        ValidAudience = Configuration["JWT:VALID_AUDIENCE"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["JWT:SECRET"])
                        )
                    };
                });

            //Mapper para la aplicacion.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CONCERTACIÓN API",
                    Version = "v1",
                    Description = "API exclusivo para el manejo de los servicios que soportan el backend del sistema de concertación para el apoyo de las convocatorias que se realiza online.",
                    TermsOfService = new Uri("https://mincultura.gov.co/planes-y-programas/programas/programa-nacional-de-concertaci%C3%B3n-cultural/Paginas/Programa%20Nacional%20de%20Concertaci%C3%B3n%20Cultural.aspx"),
                    Contact = new OpenApiContact
                    {
                        Name = "Milton Montenegro Rodríguez",
                        Email = "mmontenegro@mincultura.gov.co",
                        Url = new Uri("https://www.linkedin.com/in/milton-jos%C3%A9-montenegro-rodr%C3%ADguez-b5321b59/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();
                c.CustomSchemaIds(type => type.ToString());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Enable Call * Origins + any method + any header
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            //Requerido por el JWT
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CONCERTACIÓN API V1");
            });

        }
    }
}
