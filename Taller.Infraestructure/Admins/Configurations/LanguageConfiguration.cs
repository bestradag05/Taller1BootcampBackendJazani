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
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("language", "adm"); //Primer agumento nombre de la tabla y segundo es el equema
            builder.HasKey(t => t.Id); //Determinamos el primaryKey
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Abbreviation).HasColumnName("abbreviation");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");



        }
    }
}
