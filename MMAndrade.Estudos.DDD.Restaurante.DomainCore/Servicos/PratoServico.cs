using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;
using MMAndrade.Estudos.DDD.Restaurante.DomainCore.Interfaces.Repositorios;
using MMAndrade.Estudos.DDD.Restaurante.DomainCore.Interfaces.Servicos;

namespace MMAndrade.Estudos.DDD.Restaurante.DomainCore.Servicos
{
    public class PratoServico : ServicoBase<Prato>, IPratoServico
    {
        public PratoServico(IPratoRepositorio repositorio)
            : base(repositorio)
        {

        }
    }
}
