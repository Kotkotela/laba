using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ayditoryaRepository : RepositoryBase<Ayditorya>, IAyditoryaRepository
    {
        public ayditoryaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        void IAyditoryaRepository.CreateAyditorya(Ayditorya ayditorya)
        {
            throw new NotImplementedException();
        }

        void IAyditoryaRepository.DeleteAyditorya(Ayditorya ayditorya)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Ayditorya>> IAyditoryaRepository.GetAllAyditoryasAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        Task<Ayditorya> IAyditoryaRepository.GetAyditoryaAsync(Guid ayditoryaId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Ayditorya>> IAyditoryaRepository.GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
