using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Veiculo
    {
        public Veiculo()
        {
            Habilidades = new List<Habilidade>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int FabricanteId { get; set; }
        public virtual Fabricante Fabricante { get; set; }
        [Required]
        public int Ano { get; set; }
        [Required]
        public string Cor { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int TipoDeVeiculoId { get; set; }
        public virtual TipoDeVeiculo TipoDeVeiculo { get; set; }
        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
