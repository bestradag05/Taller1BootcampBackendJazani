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
    public class LanguageMenuConfiguration : IEntityTypeConfiguration<LanguageMenu>
    {
        public void Configure(EntityTypeBuilder<LanguageMenu> builder)
        {
            builder.ToTable("languagemenu", "adm"); //Primer agrgumento nombre de la tabla y el segundo es el esquema
            builder.HasKey(t => t.languageId); //Determinamos el primaryKey
            builder.Property(t => t.MenuId).HasColumnName("menuid");
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
