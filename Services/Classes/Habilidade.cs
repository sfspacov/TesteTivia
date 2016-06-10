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

            public IEnumerable<HabilidadeVM> List(int? id = default(int?))
            {
                var query = id == null ? _base.List() : _base.List().Where(x => x.Id == id);

                var lista = query.OrderBy(x => x.Nome).ToList();

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