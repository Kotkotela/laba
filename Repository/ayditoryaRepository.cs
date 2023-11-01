using Entities;
using Entities.Models;

namespace Repository
{
    public class ayditoryaRepository : RepositoryBase<Ayditorya>, IayditoryaRepository
    {
        public ayditoryaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
    }
}
