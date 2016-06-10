using Infra.ViewModels;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IFabricanteService
    {
        IEnumerable<FabricanteVM> List(int? id = null);
    }
}