using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;
using Taller.Infraestructure.Cores.Context;
using Taller.Infraestructure.Cores.Persistences;

namespace Taller.Infraestructure.Admins.Persistence
{
    public class PeriodTypeRespository : CrudRepository<PeriodType, int>, IPeriodTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PeriodTypeRespository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
