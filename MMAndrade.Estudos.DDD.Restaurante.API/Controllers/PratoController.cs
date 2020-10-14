using MMAndrade.Estudos.DDD.Restaurante.Application.DTOs;
using MMAndrade.Estudos.DDD.Restaurante.Application.Interfaces;
using MMAndrade.Estudos.DDD.Restaurante.Domain.Entitidades;

namespace MMAndrade.Estudos.DDD.Restaurante.API.Controllers
{
    public class PratoController : BaseController<Prato, PratoDTO>
    {
        public PratoController(IPratoApp app)
            : base(app)
        { }
    }

}
