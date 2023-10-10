using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Core.Paginations;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;
using Taller.Domain.Cores.Paginations;
using Taller.Infraestructure.Cores.Context;
using Taller.Infraestructure.Cores.Paginations;
using Taller.Infraestructure.Cores.Persistences;

namespace Taller.Infraestructure.Admins.Persistence
{
    public class InvestmentRespository : CrudRepository<Investment, int>, IInvestmentRepository 
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPagination<Investment> _paginator;

        public InvestmentRespository(ApplicationDbContext dbContext, IPagination<Investment> paginator) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
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

        public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
        {
            var filter = request.Filter;

            var query = _dbContext.Set<Investment>().AsQueryable();

            if (filter is not null)
            {
                query = query
                    .Where(x =>
                        
                        (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper()))
                        && (x.State == filter.State)
                        && (filter.Year == null || x.Year == filter.Year)

                    );
            }




            query = query.OrderByDescending(x => x.Id);

            query = query.Include(t => t.Document)
            .Include(t => t.Holder)
            .Include(t => t.InvestmentConcept)
            .Include(t => t.InvestmentType)
            .Include(t => t.MeasureUnit)
            .Include(t => t.MiningConcession)
            .Include(t => t.PeriodType);

            return await _paginator.Paginate(query, request);
        }
    }
}
