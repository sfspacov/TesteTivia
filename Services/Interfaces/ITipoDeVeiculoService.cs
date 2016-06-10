using Infra.ViewModels;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface ITipoDeVeiculoService
    {
        IEnumerable<TipoDeVeiculoVM> List(int? id = null);
    }
}