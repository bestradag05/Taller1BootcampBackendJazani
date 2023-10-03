

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taller.Domain.Admins.Models;

namespace Taller.Infraestructure.Admins.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("menu", "adm"); //Primer agrgumento nombre de la tabla y el segundo es el esquema
            builder.HasKey(t => t.Id); //Determinamos el primaryKey
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Order).HasColumnName("order");
            builder.Property(t => t.Level).HasColumnName("level");
            builder.Property(t => t.Visible).HasColumnName("visible");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
