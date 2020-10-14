using Microsoft.AspNetCore.Mvc;
using MMAndrade.Estudos.DDD.Restaurante.Application.DTOs;
using MMAndrade.Estudos.DDD.Restaurante.Application.Interfaces;
using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;
using System;

namespace MMAndrade.Estudos.DDD.Restaurante.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Entidade, EntidadeDTO> : ControllerBase
     where Entidade : EntidadeBase
     where EntidadeDTO : BaseDTO
    {
        readonly protected IAppBase<Entidade, EntidadeDTO> _appBase;

        public BaseController(IAppBase<Entidade, EntidadeDTO> appBase)
        {
            _appBase = appBase;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Listar()
        {
            try
            {
                var restaurantes = _appBase.SelecionarTodos();
                return new OkObjectResult(restaurantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult SelecionarPorId(int id)
        {
            try
            {
                var restaurantes = _appBase.SelecionarPorId(id);
                return new OkObjectResult(restaurantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] EntidadeDTO dado)
        {
            try
            {
                return new OkObjectResult(_appBase.Incluir(dado));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] EntidadeDTO dado)
        {
            try
            {
                _appBase.Alterar(dado);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _appBase.Excluir(id);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
