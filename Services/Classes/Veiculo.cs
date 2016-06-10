using Domain.Data;
using Infra.ViewModels;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services.Classes
{
    public abstract partial class Service
    {
        private static MeuDataContext contexto = new MeuDataContext();

        public class Veiculo : IVeiculoService
        {
            private IBaseService<Domain.Models.Habilidade> _habilidadeService;
            private IBaseService<Domain.Models.Veiculo> _base;

            public Veiculo()
            {
                _habilidadeService = new BaseService<Domain.Models.Habilidade>(contexto);
                _base = new BaseService<Domain.Models.Veiculo>(contexto);
            }

            public void Add(VeiculoVM viewModel)
            {
                var entidade = new Domain.Models.Veiculo
                {
                    Ano = viewModel.Ano,
                    Cor = viewModel.Cor,
                    Nome = viewModel.Nome,
                    FabricanteId = viewModel.Fabricante.Id,
                    TipoDeVeiculoId = viewModel.TipoDeVeiculo.Id,
                };

                foreach (var item in viewModel.Habilidades)
                {
                    var first = _habilidadeService.Find(item.Id);

                    if (first != null)
                        entidade.Habilidades.Add(first);
                }

                _base.Add(entidade);
            }

            public void Remove(int id)
            {
                var entidade = _base.Find(id);
                _base.Remove(entidade);
            }

            public void Edit(VeiculoVM viewModel)
            {
                var entidade = _base.Find(viewModel.Id);

                if (entidade != null)
                {
                    entidade.Ano = viewModel.Ano;
                    entidade.Cor = viewModel.Cor;
                    entidade.Nome = viewModel.Nome;
                    entidade.FabricanteId = viewModel.Fabricante.Id;
                    entidade.TipoDeVeiculoId = viewModel.TipoDeVeiculo.Id;
                }

                for (int i = entidade.Habilidades.Count - 1; i >= 0; i--)
                {
                    var item = entidade.Habilidades.ElementAt(i);
                    entidade.Habilidades.Remove(item);
                }

                foreach (var item in viewModel.Habilidades)
                {
                    var first = _habilidadeService.Find(item.Id);

                    if (first != null)
                        entidade.Habilidades.Add(first);
                }

                _base.Edit(entidade);
            }

            public VeiculoVM Find(int id)
            {
                return List(id).FirstOrDefault();
            }

            public IEnumerable<VeiculoVM> List(int? id = null)
            {
                var query = _base.List();

                if (id != null)
                    query = query.Where(x => x.Id == id);

                var lista = query.OrderBy(x => x.Nome).ToList();

                foreach (var item in lista)
                {
                    var veiculo = new VeiculoVM
                    {
                        Id = item.Id,
                        Ano = item.Ano,
                        Cor = item.Cor,
                        Fabricante = new FabricanteVM
                        {
                            Id = item.Fabricante.Id,
                            Nome = item.Fabricante.Nome,
                            Logo = item.Fabricante.Logo,
                            Nacao = new NacaoVM
                            {
                                Id = item.Fabricante.Nacao.Id,
                                Nome = item.Fabricante.Nacao.Nome,
                                Bandeira = item.Fabricante.Nacao.Bandeira
                            }
                        },
                        Nome = item.Nome,
                        TipoDeVeiculo = new TipoDeVeiculoVM
                        {
                            Id = item.TipoDeVeiculo.Id,
                            Nome = item.TipoDeVeiculo.Nome,
                            Descricao = item.TipoDeVeiculo.Descricao,
                        },
                    };

                    foreach (var habilidade in item.Habilidades)
                    {
                        var first = item.Habilidades.FirstOrDefault(x => x.Id == habilidade.Id);
                        if (first != null)
                        {
                            veiculo.Habilidades.Add(new HabilidadeVM
                            {
                                Id = first.Id,
                                Nome = first.Nome,
                                Descricao = first.Descricao
                            });
                        }
                    }

                    yield return veiculo;
                }
            }
        }
    }
}