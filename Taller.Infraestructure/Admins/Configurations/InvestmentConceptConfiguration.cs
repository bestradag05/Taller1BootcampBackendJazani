

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taller.Domain.Admins.Models;
using Taller.Infraestructure.Cores.Converters;

namespace Taller.Infraestructure.Admins.Configurations
{
    public class InvestmentConceptConfiguration : IEntityTypeConfiguration<InvestmentConcept>
    {
        public void Configure(EntityTypeBuilder<InvestmentConcept> builder)
        {
            builder.ToTable("investmentconcept", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
