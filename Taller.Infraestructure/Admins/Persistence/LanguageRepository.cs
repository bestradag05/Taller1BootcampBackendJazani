using Microsoft.EntityFrameworkCore;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;
using Taller.Infraestructure.Cores.Context;
using Taller.Infraestructure.Cores.Persistences;

namespace Taller.Infraestructure.Admins.Persistence
{
    public class LanguageRepository : CrudRepository<Language, int>, ILanguageRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LanguageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
             _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Language>> FindAllAsync()
        {
            return await _dbContext.Set<Language>().Include(t => t.Menus).AsNoTracking().ToListAsync();
        }

        public override async Task<Language?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Language>()
                .Include(t => t.Menus)
                .FirstOrDefaultAsync(t => t.Id == id);
        }


    }
}
