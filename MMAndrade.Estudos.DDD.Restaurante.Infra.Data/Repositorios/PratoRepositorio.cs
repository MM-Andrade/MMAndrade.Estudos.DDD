using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;
using MMAndrade.Estudos.DDD.Restaurante.DomainCore.Interfaces.Repositorios;
using MMAndrade.Estudos.DDD.Restaurante.Infra.Data.Contexto;

namespace MMAndrade.Estudos.DDD.Restaurante.Infra.Data.Repositorios
{
    public class PratoRepositorio : RepositorioBase<Prato>, IPratoRepositorio
    {
        public PratoRepositorio(DatabaseContext contexto)
            : base(contexto)
        {
        }
    }
}
