using Infra.ViewModels;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IVeiculoService
    {
        void Add(VeiculoVM viewModel);
        void Edit(VeiculoVM viewModel);

        IEnumerable<VeiculoVM> List(int? id = null);
        void Remove(int id);

        VeiculoVM Find(int id);
    }
}