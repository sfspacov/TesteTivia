using Infra.ViewModels;
using Services.Classes;
using Services.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class FabricanteController : ApiController
    {
        private IFabricanteService _fabricanteService;

        public FabricanteController()
        {
            _fabricanteService = new Service.Fabricante();
        }

        public IEnumerable<FabricanteVM> Get()
        {
            return _fabricanteService.List();
        }
    }
}