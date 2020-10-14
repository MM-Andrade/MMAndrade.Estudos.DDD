using AutoMapper;
using MMAndrade.Estudos.DDD.Restaurante.Application.DTOs;
using MMAndrade.Estudos.DDD.Restaurante.Application.Interfaces;
using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;
using MMAndrade.Estudos.DDD.Restaurante.DomainCore.Interfaces.Servicos;

namespace MMAndrade.Estudos.DDD.Restaurante.Application.Servicos
{
    public class PratoApp : ServicoAppBase<Prato, PratoDTO>, IPratoApp
    {
        public PratoApp(IMapper iMapper, IPratoServico servico)
            : base(iMapper, servico)
        {

        }
    }
}
