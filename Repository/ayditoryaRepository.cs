using Entities;
using Entities.Models;

namespace Repository
{
    public class ayditoryaRepository : RepositoryBase<ayditorya>, IayditoryaRepository
    {
        public ayditoryaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
    }
}
