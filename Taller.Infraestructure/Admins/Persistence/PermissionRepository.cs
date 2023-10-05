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
    public class PermissionRepository : CrudRepository<Permission, int>, IPermissionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PermissionRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Permission>> FindAllAsync()
        {
            return await _dbContext.Set<Permission>().Include(t => t.Menus).AsNoTracking().ToListAsync();
        }

        public override async Task<Permission?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Permission>()
                .Include(t => t.Menus)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
