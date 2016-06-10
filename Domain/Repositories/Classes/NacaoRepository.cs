using Domain.Data;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Domain.Repositories.Classes
{
    public class NacaoRepository : BaseRepository<Nacao>, INacaoRepository
    {
        IUnitOfWork unitOfWork = new MeuDataContext();

        public NacaoRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }
    }
}
