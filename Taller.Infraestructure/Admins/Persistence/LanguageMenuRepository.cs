using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;
using Taller.Domain.Admins.Repositories;
using Taller.Infraestructure.Cores.Context;

namespace Taller.Infraestructure.Admins.Persistence
{
    public class LanguageMenuRepository : ILanguageMenuRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public LanguageMenuRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<LanguageMenu>> FindAllAsync()
        {
            return await _dbContext.LanguageMenus.ToListAsync();
        }

        public async Task<LanguageMenu?> FindByIdAsync(int id)
        {
            return await _dbContext.LanguageMenus.FirstOrDefaultAsync(x => x.languageId == id);
        }

        public async Task<LanguageMenu?> SaveAsync(LanguageMenu languagemenu)
        {
            EntityState state = _dbContext.Entry(languagemenu).State;
            //switch mejorado de c#

            _ = state switch
            {
                EntityState.Detached => _dbContext.LanguageMenus.Add(languagemenu),
                EntityState.Modified => _dbContext.LanguageMenus.Update(languagemenu)

            };

            await _dbContext.SaveChangesAsync();

            return languagemenu;
        }

    }
}
