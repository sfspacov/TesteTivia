using Domain.Data;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Classes
{
    public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
    {
        IUnitOfWork unitOfWork = new MeuDataContext();

        public VeiculoRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
