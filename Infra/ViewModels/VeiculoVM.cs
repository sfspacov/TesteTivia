using System.Collections.Generic;

namespace Infra.ViewModels
{
    public class VeiculoVM
    {
        public VeiculoVM()
        {
            Habilidades = new List<HabilidadeVM>();
        }
        public int Id { get; set; }
        public int TipoDeVeiculoId { get; set; }
        public int FabricanteId { get; set; }
        public int Ano { get; set; }
        public string Cor { get; set; }
        public string Nome { get; set; }
        public virtual FabricanteVM Fabricante { get; set; }
        public virtual TipoDeVeiculoVM TipoDeVeiculo { get; set; }
        public virtual ICollection<HabilidadeVM> Habilidades { get; set; }
    }
}