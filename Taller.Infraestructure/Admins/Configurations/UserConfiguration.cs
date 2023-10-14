using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;
using Taller.Infraestructure.Cores.Converters;

namespace Taller.Infraestructure.Admins.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "adm"); //Primer agumento nombre de la tabla y segundo es el equema
            builder.HasKey(t => t.Id); //Determinamos el primaryKey
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.LastName).HasColumnName("lastname");
            builder.Property(t => t.Email).HasColumnName("email");
            builder.Property(t => t.Password).HasColumnName
               ("password");
            builder.Property(t => t.RoleId).HasColumnName("roleid");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

        }
    }
}
