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
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public MenuRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Menu>> FindAllAsync()
        {
            return await _dbContext.Menus.ToListAsync();
        }

        public async Task<Menu?> FindByIdAsync(int id)
        {
           return await _dbContext.Menus.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Menu?> SaveAsync(Menu menu)
        {
            EntityState state = _dbContext.Entry(menu).State;
            //switch mejorado de c#

            _ = state switch
            {
                EntityState.Detached => _dbContext.Menus.Add(menu),
                EntityState.Modified => _dbContext.Menus.Update(menu)

            };

            await _dbContext.SaveChangesAsync();

            return menu;
        }
    }
}
