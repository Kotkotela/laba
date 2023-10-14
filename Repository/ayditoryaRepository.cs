using Entities;
using Entities.Models;
using Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contracts.Contracts;

namespace Repository
{
    public class AyditoryaRepository : RepositoryBase<ayditorya>, IayditoryaRepository
    {
        public ayditoryaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
    }
}
