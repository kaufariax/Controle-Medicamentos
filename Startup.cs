using ControleMedicamentos.src.contexto;
using ControleMedicamentos.src.repositorios;
using ControleMedicamentos.src.repositorios.implementacoes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace ControleMedicamentos
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
            //Banco de Dados
            if(Configuration ["Enviroment:Start"] == "PROD")
            {
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<CM_Contexto>(
                    opt =>
                    opt.UseNpgsql(Configuration["ConnectionStringsProd:DefaultConnection"]));
            }
            else
            {
                services.AddDbContext<CM_Contexto>(
                    opt =>
                    opt.UseSqlServer(Configuration["ConnectionStringsDev:DefaultConnection"]));
            }

            // Repositorios
            services.AddScoped<IPaciente, PacienteRepositorio>();
            services.AddScoped<IMedicamento, MedicamentoRepositorio>();
            services.AddScoped<IControleDados, ControleDadosRepositorio>();

            //Controladores
            services.AddCors();
            services.AddControllers();

            // Configuração Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Controle de Medicamentos", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CM_Contexto contexto)
        {
            // Ambiente de Desenvolvimento
            if (env.IsDevelopment())
            {
                contexto.Database.EnsureCreated();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleMedicamentos v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            // Ambiente de Produção
            contexto.Database.EnsureCreated();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ControleMedicamentos v1");
                c.RoutePrefix = string.Empty;
            });

            // Rotas
            app.UseRouting();

            app.UseCors(c => c
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
           );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
