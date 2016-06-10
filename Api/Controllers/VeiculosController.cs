using Infra.ViewModels;
using Services.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    public class VeiculosController : ApiController
    {
        private IVeiculoService _veiculoService;

        public VeiculosController()
        {
            _veiculoService = new Service.Veiculo();
        }

        public IEnumerable<VeiculoVM> Get()
        {
            return _veiculoService.List();
        }

        public VeiculoVM Get(int id)
        {
            return _veiculoService.Find(id);
        }

        public void Post([FromBody]VeiculoVM viewModel)
        {
            if (ModelState.IsValid)
            {
                _veiculoService.Add(viewModel);
            }
            else
            {
                throw new Exception("Model inválida");
            }
        }

        public void Put([FromBody]VeiculoVM viewModel)
        {
            if (ModelState.IsValid)
            {
                _veiculoService.Edit(viewModel);
            }
            else
            {
                throw new Exception("Model inválida");
            }
        }

        public void Delete(int id)
        {
            _veiculoService.Remove(id);
        }
    }
}