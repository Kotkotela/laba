using Entities.Models;
using Entities;
using static Contracts.Contracts;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromCompanyRepository()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
       FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();
    }
}
