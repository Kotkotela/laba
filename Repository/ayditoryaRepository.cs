using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ayditoryaRepository : RepositoryBase<Ayditorya>, IAyditoryaRepository
    {
        public ayditoryaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public void CreateAyditoria(Ayditorya Ayditoria)
        {
            throw new NotImplementedException();
        }

        public void DeleteAyditoria(Ayditorya ayditorya)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ayditorya>> GetAllAyditoriasAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ayditorya>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Ayditorya> GetAyditoryaAsync(Guid AyditoriaeId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
