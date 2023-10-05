using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Taller.Domain.Admins.Models;
using Taller.Infraestructure.Admins.Configurations;

namespace Taller.Infraestructure.Cores.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           // modelBuilder.Entity<Language>()
           //.HasMany(e => e.Menus)
           //.WithMany(e => e.Languages)
           //.UsingEntity(
           // l => l.HasOne(typeof(Menu)).WithMany().HasForeignKey("menuid"),
           // r => r.HasOne(typeof(Language)).WithMany().HasForeignKey("languageid"));

           // modelBuilder.Entity<Permission>()
           //.HasMany(e => e.Menus)
           //.WithMany(e => e.Permissions)
           //.UsingEntity(
           //     "rolemenupermission",
           // l => l.HasOne(typeof(Menu)).WithMany().HasForeignKey("menuid"),
           // r => r.HasOne(typeof(Permission)).WithMany().HasForeignKey("permissionid"));


        }



    }
}
