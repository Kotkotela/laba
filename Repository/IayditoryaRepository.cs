using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class AyditoryaRepository : RepositoryBase<Ayditorya>, IAyditoryaRepository
    {
        public AyditoryaRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<IEnumerable<Ayditorya>> GetAllAyditoryasAsync(bool trackChanges) => await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();
        public async Task<Ayditorya> GetAyditoryaAsync(Guid AyditoryaId, bool trackChanges) => await FindByCondition(c => c.Id.Equals(AyditoryaId), trackChanges)
            .SingleOrDefaultAsync();
        public void CreateAyditorya(Ayditorya Ayditorya) => Create(Ayditorya);
        public async Task<IEnumerable<Ayditorya>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) => await FindByCondition(x => ids.Contains(x.Id), trackChanges)
            .ToListAsync();
        public void DeleteAyditorya(Ayditorya Ayditorya)
        {
            Delete(Ayditorya);
        }

        Task<IEnumerable<Ayditorya>> IAyditoryaRepository.GetAllAyditoriasAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }


        void IAyditoryaRepository.CreateAyditoria(Ayditorya Ayditoria)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Ayditorya>> IAyditoryaRepository.GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        void IAyditoryaRepository.DeleteAyditoria(Ayditorya grade)
        {
            throw new NotImplementedException();
        }
    }
}