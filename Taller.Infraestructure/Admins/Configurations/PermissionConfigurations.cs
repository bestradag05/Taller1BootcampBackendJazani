using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Models;

namespace Taller.Infraestructure.Admins.Configurations
{
    public class PermissionConfigurations : IEntityTypeConfiguration<Permission>
    {

        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permission", "adm"); //Primer agrgumento nombre de la tabla y el segundo es el esquema
            builder.HasKey(t => t.Id); //Determinamos el primaryKey
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Slug).HasColumnName("slug");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(t => t.State).HasColumnName("state");
        }
    }

}
