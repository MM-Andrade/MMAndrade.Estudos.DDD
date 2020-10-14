using MMAndrade.Estudos.DDD.Restaurante.Application.DTOs;
using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;
using System.Collections.Generic;

namespace MMAndrade.Estudos.DDD.Restaurante.Application.Interfaces
{
    public interface IAppBase<TEntidade, TEntidadeDTO> 
        where TEntidade : EntidadeBase where TEntidadeDTO : BaseDTO
    {
        int Incluir(TEntidadeDTO entidade);
        void Excluir(int id);
        void Excluir(TEntidadeDTO entidade);
        void Alterar(TEntidadeDTO entidade);
        TEntidadeDTO SelecionarPorId(int id);
        IEnumerable<TEntidadeDTO> SelecionarTodos();
    }
}
