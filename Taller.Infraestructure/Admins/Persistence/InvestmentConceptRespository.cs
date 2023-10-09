using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;
using Taller.Infraestructure.Cores.Context;
using Taller.Infraestructure.Cores.Persistences;

namespace Taller.Infraestructure.Admins.Persistence
{
    public class InvestmentConceptRespository : CrudRepository<InvestmentConcept, int>, IInvestmentConceptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvestmentConceptRespository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
