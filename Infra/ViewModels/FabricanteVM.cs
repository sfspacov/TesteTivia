namespace Infra.ViewModels
{
    public class FabricanteVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Logo { get; set; }
        public virtual NacaoVM Nacao { get; set; }
    }
}