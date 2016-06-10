using Domain.Data;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Classes
{
    public class FabricanteRepository : BaseRepository<Fabricante>, IFabricanteRepository
    {
        IUnitOfWork unitOfWork = new MeuDataContext();

        public FabricanteRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
