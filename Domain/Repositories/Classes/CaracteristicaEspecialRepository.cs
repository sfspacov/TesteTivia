using Domain.Data;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Classes
{
    public class CaracteristicaEspecialRepository : BaseRepository<Habilidade>, ICaracteristicaEspecialRepository
    {
        IUnitOfWork unitOfWork = new MeuDataContext();

        public CaracteristicaEspecialRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
