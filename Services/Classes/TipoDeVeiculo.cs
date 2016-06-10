using Infra.ViewModels;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Classes
{
    public abstract partial class Service
    {
        public class TipoDeVeiculo : ITipoDeVeiculoService
        {
            private IBaseService<Domain.Models.TipoDeVeiculo> _base;

            public TipoDeVeiculo()
            {
                _base = new BaseService<Domain.Models.TipoDeVeiculo>(contexto);
            }

            public IEnumerable<TipoDeVeiculoVM> List()
            {
                var lista = _base.List().OrderBy(x => x.Nome).ToList();

                foreach (var item in lista)
                {
                    yield return new TipoDeVeiculoVM
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Descricao = item.Descricao
                    };
                }
            }
        }
    }
}