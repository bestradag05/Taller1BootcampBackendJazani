using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Taller.Domain.Admins.Models;
using Taller.Infraestructure.Admins.Configurations;

namespace Taller.Infraestructure.Cores.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region "DbSet"

        public DbSet<Menu> Menus { get; set; }
        public DbSet<LanguageMenu> LanguageMenus { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageMenuConfiguration());
        }



    }
}
