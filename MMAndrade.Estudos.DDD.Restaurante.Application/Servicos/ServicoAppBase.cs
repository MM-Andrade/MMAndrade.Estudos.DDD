using AutoMapper;
using MMAndrade.Estudos.DDD.Restaurante.Application.DTOs;
using MMAndrade.Estudos.DDD.Restaurante.Application.Interfaces;
using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;
using MMAndrade.Estudos.DDD.Restaurante.DomainCore.Interfaces.Servicos;
using System.Collections.Generic;

namespace MMAndrade.Estudos.DDD.Restaurante.Application.Servicos
{
    public class ServicoAppBase<TEntidade, TEntidadeDTO> : IAppBase<TEntidade, TEntidadeDTO>
         where TEntidade : EntidadeBase
         where TEntidadeDTO : BaseDTO
    {
        protected readonly IServicoBase<TEntidade> servico;
        protected readonly IMapper iMapper;

        public ServicoAppBase(IMapper iMapper, IServicoBase<TEntidade> servico)
            : base()
        {
            this.iMapper = iMapper;
            this.servico = servico;
        }

        public void Alterar(TEntidadeDTO entidade)
        {
            servico.Alterar(iMapper.Map<TEntidade>(entidade));
        }

        public void Excluir(int id)
        {
            servico.Excluir(id);
        }

        public void Excluir(TEntidadeDTO entidade)
        {
            servico.Excluir(iMapper.Map<TEntidade>(entidade));
        }

        public int Incluir(TEntidadeDTO entidade)
        {
            return servico.Incluir(iMapper.Map<TEntidade>(entidade));
        }

        public TEntidadeDTO SelecionarPorId(int id)
        {
            return iMapper.Map<TEntidadeDTO>(servico.SelecionarPorId(id));
        }

        public IEnumerable<TEntidadeDTO> SelecionarTodos()
        {
            return iMapper.Map<IEnumerable<TEntidadeDTO>>(servico.SelecionarTodos());
        }
    }
}
