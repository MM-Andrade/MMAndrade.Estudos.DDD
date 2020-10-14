using Microsoft.Extensions.DependencyInjection;
using MMAndrade.Estudos.DDD.Restaurante.Application.Interfaces;
using MMAndrade.Estudos.DDD.Restaurante.Application.Servicos;
using MMAndrade.Estudos.DDD.Restaurante.DomainCore.Interfaces.Repositorios;
using MMAndrade.Estudos.DDD.Restaurante.DomainCore.Interfaces.Servicos;
using MMAndrade.Estudos.DDD.Restaurante.DomainCore.Servicos;
using MMAndrade.Estudos.DDD.Restaurante.Infra.Data.Repositorios;

namespace MMAndrade.Estudos.DDD.Restaurante.Infra.IoC
{

    /// <summary>
    /// Classe responsável por centralizar e controlara injeção de todas as dependências do projeto
    /// </summary>
    public class InjetorDependencias
    {
        /// <summary>
        /// Método responsável por realizar o registro de dependências nas camadas de serviços e aplicação
        /// </summary>
        /// <param name="svcCollection">Collection ser serviços a serem registrados</param>
        public static void Registrar(IServiceCollection svcCollection)
        {
            //Aplicação
            svcCollection.AddScoped(typeof(IAppBase<,>), typeof(ServicoAppBase<,>));
            svcCollection.AddScoped<IPratoApp, PratoApp>();

            //Domínio
            svcCollection.AddScoped(typeof(IServicoBase<>), typeof(ServicoBase<>));
            svcCollection.AddScoped<IPratoServico, PratoServico>();

            //Repositorio
            svcCollection.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            svcCollection.AddScoped<IPratoRepositorio, PratoRepositorio>();
        }
    }
}

