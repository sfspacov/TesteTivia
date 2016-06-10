using Infra.ViewModels;
using Services.Classes;
using Services.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class TipoDeVeiculoController : ApiController
    {
        private ITipoDeVeiculoService _tipoDeVeiculoService;

        public TipoDeVeiculoController()
        {
            _tipoDeVeiculoService = new Service.TipoDeVeiculo();
        }

        public IEnumerable<TipoDeVeiculoVM> Get()
        {
            return _tipoDeVeiculoService.List();
        }
    }
}