using Infra.ViewModels;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IHabilidadeService
    {
        IEnumerable<HabilidadeVM> List();
    }
}