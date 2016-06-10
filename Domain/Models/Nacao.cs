using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Nacao
    {
        public Nacao()
        {
            Fabricantes = new List<Fabricante>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Bandeira { get; set; }
        public virtual ICollection<Fabricante> Fabricantes { get; set; }
    }
}
