using Infra.ViewModels;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Classes
{
    public abstract partial class Service
    {
        public class Fabricante : IFabricanteService
        {
            private IBaseService<Domain.Models.Fabricante> _base;

            public Fabricante()
            {
                _base = new BaseService<Domain.Models.Fabricante>(contexto);
            }

            public IEnumerable<FabricanteVM> List()
            {
                var lista = _base.List().OrderBy(x => x.Nome).ToList();

                foreach (var item in lista)
                {
                    yield return new FabricanteVM
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Logo = item.Logo
                    };
                }
            }
        }
    }
}