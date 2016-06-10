using Domain.Models;
using Domain.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Domain.Data
{
    public class MeuDataContext : DbContext, IUnitOfWork
    {
        public MeuDataContext() : base("name=myConnectionString")
        {
            Database.SetInitializer(new UniDBInitializer<MeuDataContext>());
        }

        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<Habilidade> Habilidade { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<Nacao> Nacao { get; set; }
        public DbSet<TipoDeVeiculo> TipoDeVeiculo { get; set; }

        public void Save()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();
        }

        private class UniDBInitializer<T> : DropCreateDatabaseAlways<MeuDataContext>
        {
            protected override void Seed(MeuDataContext context)
            {
                PopularNacoes(context);

                PopularFabricantes(context);

                PopularTiposDeVeiculos(context);

                PopularHabilidades(context);

                context.Save();

                PopularVeiculos(context);

                context.Save();
            }

            private static void PopularVeiculos(MeuDataContext context)
            {
                var carac1 = context.Habilidade.First(x => x.Id == 1);
                var carac2 = context.Habilidade.First(x => x.Id == 2);
                var carac3 = context.Habilidade.First(x => x.Id == 3);
                var carac4 = context.Habilidade.First(x => x.Id == 4);
                var carac5 = context.Habilidade.First(x => x.Id == 5);
                var carac6 = context.Habilidade.First(x => x.Id == 6);
                var carac7 = context.Habilidade.First(x => x.Id == 7);
                var carac8 = context.Habilidade.First(x => x.Id == 8);

                var veiculo1 = new
                    Veiculo
                {
                    Id = 1,
                    FabricanteId = 1,
                    TipoDeVeiculoId = 1,
                    Nome = "Audi TT",
                    Ano = 2007,
                    Cor = "Prateado",
                    Habilidades = {
                        carac5
                    }
                };

                var veiculo2 = new
                    Veiculo
                {
                    Id = 2,
                    FabricanteId = 2,
                    TipoDeVeiculoId = 2,
                    Nome = "Azira",
                    Ano = 2013,
                    Cor = "Preto",
                    Habilidades =
                    {
                        carac2,
                        carac8
                    }
                };

                var veiculo3 = new
                   Veiculo
                {
                    Id = 3,
                    FabricanteId = 3,
                    TipoDeVeiculoId = 3,
                    Nome = "Maranello",
                    Ano = 2005,
                    Cor = "Vermelho",
                    Habilidades =
                    {
                        carac2
                    }
                };

                var veiculo4 = new
                   Veiculo
                {
                    Id = 4,
                    FabricanteId = 4,
                    TipoDeVeiculoId = 1,
                    Nome = "Corolla",
                    Ano = 2015,
                    Cor = "Preto",
                    Habilidades =
                    {
                        carac4,
                        carac5
                    }
                };

                var veiculo5 = new
                   Veiculo
                {
                    Id = 5,
                    FabricanteId = 5,
                    TipoDeVeiculoId = 5,
                    Nome = "Mustang",
                    Ano = 1962,
                    Cor = "Amarela com faixa preta",
                    Habilidades =
                    {
                        carac3
                    }
                };

                var veiculo6 = new
                   Veiculo
                {
                    Id = 6,
                    FabricanteId = 6,
                    TipoDeVeiculoId = 5,
                    Nome = "Camaro 77",
                    Ano = 1977,
                    Cor = "Prateado",
                    Habilidades =
                    {
                        carac3,
                        carac6,
                        carac7
                    }
                };

                var veiculo7 = new
                Veiculo
                {
                    Id = 7,
                    FabricanteId = 7,
                    TipoDeVeiculoId = 4,
                    Nome = "Jeep WW2",
                    Ano = 1982,
                    Cor = "Verde escuro",
                    Habilidades =
                    {
                        carac1
                    }
                };

                context.Veiculo.AddRange(new List<Veiculo> {
                    veiculo1,
                    veiculo2,
                    veiculo3,
                    veiculo4,
                    veiculo5
                    ,veiculo6
                    ,veiculo7
                });
            }

            private static void PopularHabilidades(MeuDataContext context)
            {
                context.Habilidade.AddRange(new List<Habilidade> {
                    new Habilidade
                    {
                        Id = 1,
                        Nome = "4 x 4",
                        Descricao = "As quatro rodas possuem tração"
                    },
                    new Habilidade
                    {
                        Id = 2,
                        Nome = "Automático",
                        Descricao = "Cambio automático"
                    }, new Habilidade
                    {
                        Id = 3,
                        Nome = "Turbo",
                        Descricao = "Quando acionado, atinge até 330 km/h"
                    }, new Habilidade
                    {
                        Id = 4,
                        Nome = "Flex",
                        Descricao = "Aceita alcool e gasolina como combustível"
                    }, new Habilidade
                    {
                        Id = 5,
                        Nome = "Rodas de liga leve",
                        Descricao = "Rodas feitas de metal de liga leve"
                    }
                    , new Habilidade
                    {
                        Id = 6,
                        Nome = "Arrancada rapida",
                        Descricao = "De 0 a 100 em 6 seg"
                    }, new Habilidade
                    {
                        Id = 7,
                        Nome = "Peças originais",
                        Descricao = "Possui mais de 90% das peças originais"
                    }, new Habilidade
                    {
                        Id = 8,
                        Nome = "Luxuoso",
                        Descricao = "Carro com todos items luxuosos"
                    }
                });
            }

            private static void PopularTiposDeVeiculos(MeuDataContext context)
            {
                context.TipoDeVeiculo.AddRange(new List<TipoDeVeiculo> {
                    new TipoDeVeiculo
                    {
                        Id = 1,
                        Nome = "Sport",
                        Descricao = "Carros rapidos e com aerodinamica arrojada"
                    }
                    ,new TipoDeVeiculo
                    {
                        Id = 2,
                        Nome = "Executivo",
                        Descricao = "Carros de alto padrão"
                    }
                    , new TipoDeVeiculo
                    {
                        Id = 3,
                        Nome = "Popular",
                        Descricao = "Carros baratos e econômicos"
                    }
                    , new TipoDeVeiculo
                    {
                        Id = 4,
                        Nome = "Off-road",
                        Descricao = "Capaz de andar na lama"
                    }
                    , new TipoDeVeiculo
                    {
                        Id = 5,
                        Nome = "Clássico",
                        Descricao = "Carro raro"
                    }
                    , new TipoDeVeiculo
                    {
                        Id = 6,
                        Nome = "SUV",
                        Descricao = "Carro grande e luxuoso"
                    }
                });
            }

            private static void PopularFabricantes(MeuDataContext context)
            {
                context.Fabricante.Add(new Fabricante
                {
                    Id = 1,
                    Nome = "Audi",
                    NacaoId = 1
                    ,Logo = "images/audi.jpg"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 2,
                    Nome = "Hyundai",
                    NacaoId = 2
                    ,Logo = "images/hyundai.png"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 3,
                    Nome = "Ferrari",
                    NacaoId = 3
                    ,Logo = "images/ferrari.png"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 4,
                    Nome = "Toyota",
                    NacaoId = 4
                    ,Logo = "images/toyota.jpg"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 5,
                    Nome = "Ford",
                    NacaoId = 5
                    ,Logo = "images/ford.jpg"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 6,
                    Nome = "Chevrolet",
                    NacaoId = 5
                    ,Logo = "images/chevrolet.jpg"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 7,
                    Nome = "Jeep",
                    NacaoId = 5
                    ,Logo = "images/jeep.jpg"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 8,
                    Nome = "Mitsubishi",
                    NacaoId = 4
                    ,Logo = "images/mitsubishi.gif"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 9,
                    Nome = "Honda",
                    NacaoId = 4
                    ,Logo = "images/honda.jpg"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 10,
                    Nome = "Fiat",
                    NacaoId = 3
                    ,Logo = "images/fiat.png"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 11,
                    Nome = "Maserati",
                    NacaoId = 3
                    ,Logo = "images/maserati.png"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 12,
                    Nome = "BMW",
                    NacaoId = 1
                    ,Logo = "images/bmw.png"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 13,
                    Nome = "Volkswagen",
                    NacaoId = 1
                    ,Logo = "images/vw.jpg"
                });
                context.Fabricante.Add(new Fabricante
                {
                    Id = 14,
                    Nome = "Mercedez-Benz",
                    NacaoId = 1
                    ,Logo = "images/mercedez.png"
                });
            }

            private static void PopularNacoes(MeuDataContext context)
            {
                context.Nacao.AddRange(new List<Nacao> {
                new Nacao
                {
                    Id = 1,
                    Bandeira = "images/Germany.gif",
                    Nome = "Alemanha"
                },
                new Nacao
                {
                    Id = 2,
                    Bandeira = "images/korea.png",
                    Nome = "Coréia do Sul"
                },
                new Nacao
                {
                    Id = 3,
                    Bandeira = "images/italy.gif",
                    Nome = "Itália"
                },
                new Nacao
                {
                    Id = 4,
                    Bandeira = "images/japan.png",
                    Nome = "Japão"
                },
                new Nacao
                {
                    Id = 5,
                    Bandeira = "images/usa.png",
                    Nome = "USA"
                }});
            }
        }
    }
}