using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMAndrade.Estudos.DDD.Restaurante.Application;
using MMAndrade.Estudos.DDD.Restaurante.Infra.Data.Contexto;
using MMAndrade.Estudos.DDD.Restaurante.Infra.IoC;

namespace MMAndrade.Estudos.DDD.Restaurante.API
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
            services.AddControllers();

            //injeção do contexto para conexão com o Banco de Dados apontando a string de conexão para o arquivo appsetings.json
            services.AddDbContext<DatabaseContext>(options => options
                        .UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));


            //Injeção de todas dependências a partir do projeto IoC
            InjetorDependencias.Registrar(services);

            //Injeção de dependência do automapper
            services.AddAutoMapper(config => config.AddProfile(new MappingEntidade()));

            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            
            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
