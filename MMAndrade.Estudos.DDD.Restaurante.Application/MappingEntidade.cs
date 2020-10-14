using AutoMapper;
using MMAndrade.Estudos.DDD.Restaurante.Application.DTOs;
using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;

namespace MMAndrade.Estudos.DDD.Restaurante.Application
{

    /// <summary>
    /// Classe responsável por fazer registrar o AutoMapper para conversão entre DTO e Entidades
    /// </summary>
    public class MappingEntidade : Profile
    {
        public MappingEntidade()
        {
            #region Prato
            CreateMap<Prato, PratoDTO>();
            CreateMap<PratoDTO, Prato>();
            #endregion
        }
    }
}
