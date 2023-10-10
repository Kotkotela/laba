using Entities.Models;
using Entities;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contracts.Contracts;

namespace Repository
{
    public class studentRepostiory : RepositoryBase<student>, IstudentRepository
    {
        public studentRepostiory(RepositoryContext repositoryContext)
            : base(repositoryContext) { }
    }
}
