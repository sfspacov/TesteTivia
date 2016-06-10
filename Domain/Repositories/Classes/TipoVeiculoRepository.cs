using Domain.Data;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Classes
{
    public class TipoVeiculoRepository : BaseRepository<TipoDeVeiculo>, ITipoVeiculoRepository
    {
        IUnitOfWork unitOfWork = new MeuDataContext();

        public TipoVeiculoRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
