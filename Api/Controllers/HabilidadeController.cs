using Infra.ViewModels;
using Services.Classes;
using Services.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class HabilidadeController : ApiController
    {
        private IHabilidadeService _habilidadeService;

        public HabilidadeController()
        {
            _habilidadeService = new Service.Habilidade();
        }

        public IEnumerable<HabilidadeVM> Get()
        {
            return _habilidadeService.List();
        }
    }
}