using Infra.ViewModels;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Classes
{
    public abstract partial class Service
    {
        public class Habilidade : IHabilidadeService
        {
            private IBaseService<Domain.Models.Habilidade> _base;

            public Habilidade()
            {
                _base = new BaseService<Domain.Models.Habilidade>(contexto);
            }

            public IEnumerable<HabilidadeVM> List()
            {
                var lista = _base.List().OrderBy(x => x.Nome).ToList();

                foreach (var item in lista)
                {
                    yield return new HabilidadeVM
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