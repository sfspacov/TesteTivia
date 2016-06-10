using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Fabricante
    {
        public Fabricante()
        {
            Veiculos = new List<Veiculo>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Logo { get; set; }
        public int NacaoId { get; set; }
        public virtual Nacao Nacao { get; set; }
        public virtual ICollection<Veiculo> Veiculos { get; set; }

    }
}
