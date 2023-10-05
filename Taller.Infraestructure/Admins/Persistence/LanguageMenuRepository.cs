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
    public class LanguageMenuRepository : CrudRepository<LanguageMenu, int>, ILanguageMenuRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public LanguageMenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public override async Task<IReadOnlyList<LanguageMenu>> FindAllAsync()
        {
            return await _dbContext.Set<LanguageMenu>().Include(t => t.Language).Include(d => d.Menu).AsNoTracking().ToListAsync();
        }

    }
}
