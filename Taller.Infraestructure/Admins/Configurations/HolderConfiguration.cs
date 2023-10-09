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
    public class HolderConfiguration : IEntityTypeConfiguration<Holder>
    {
        public void Configure(EntityTypeBuilder<Holder> builder)
        {
            builder.ToTable("holder", "soc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.LastName).HasColumnName("lastname");
            builder.Property(t => t.MaidenName).HasColumnName("maidenname");
            builder.Property(t => t.DocumentNumber).HasColumnName("documentnumber");
            builder.Property(t => t.HolderregimeId).HasColumnName("holderregimeid");
            builder.Property(t => t.HoldergroupId).HasColumnName("holdergroupid");
            builder.Property(t => t.RegistryOfficeId).HasColumnName("registryofficeid");
            builder.Property(t => t.IdentificationDocumentId).HasColumnName("identificationdocumentid");
            builder.Property(t => t.HoldertypeId).HasColumnName("holdertypeid");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
