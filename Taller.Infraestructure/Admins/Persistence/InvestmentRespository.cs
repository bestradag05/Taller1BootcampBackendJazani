using Microsoft.EntityFrameworkCore;
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
    public class InvestmentRespository : CrudRepository<Investment, int>, IInvestmentRepository 
    {
        private readonly ApplicationDbContext _dbContext;

        public InvestmentRespository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.Document)
                .Include(t => t.Holder)
                .Include(t => t.InvestmentConcept)
                .Include(t => t.InvestmentType)
                .Include(t => t.MeasureUnit)
                .Include(t => t.MiningConcession)
                .Include(t => t.PeriodType)
                .AsNoTracking().ToListAsync();
        }

        public override async Task<Investment?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.Document)
                .Include(t => t.Holder)
                .Include(t => t.InvestmentConcept)
                .Include(t => t.InvestmentType)
                .Include(t => t.MeasureUnit)
                .Include(t => t.MiningConcession)
                .Include(t => t.PeriodType)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
