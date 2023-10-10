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
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
        {
            builder.ToTable("investment", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.AmountInvestd).HasColumnName("amountinvestd").HasColumnType("decimal(9,4)"); ;
            builder.Property(t => t.Year).HasColumnName("year");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.DocumentId).HasColumnName("documentid");
            builder.Property(t => t.AccountantCode).HasColumnName("accountantcode");
            builder.Property(t => t.HolderId).HasColumnName("holderid");
            builder.Property(t => t.InvestmentConceptId).HasColumnName("investmentconceptid");
            builder.Property(t => t.InvestmentTypeId).HasColumnName("investmenttypeid");
            builder.Property(t => t.MeasureUnitId).HasColumnName("measureunitid");
            builder.Property(t => t.MiningConcessionId).HasColumnName("miningconcessionid");
            builder.Property(t => t.PeriodTypeId).HasColumnName("periodtypeid");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");

            //Relationship of tables


            builder.HasOne(one => one.Document).WithMany(many => many.Investments).HasForeignKey(fk => fk.DocumentId);
            builder.HasOne(one => one.Holder).WithMany(many => many.Investments).HasForeignKey(fk => fk.HolderId);
            builder.HasOne(one => one.InvestmentConcept).WithMany(many => many.Investments).HasForeignKey(fk => fk.InvestmentConceptId);
            builder.HasOne(one => one.InvestmentType).WithMany(many => many.Investments).HasForeignKey(fk => fk.InvestmentTypeId);
            builder.HasOne(one => one.MeasureUnit).WithMany(many => many.Investments).HasForeignKey(fk => fk.MeasureUnitId);
            builder.HasOne(one => one.MiningConcession).WithMany(many => many.Investments).HasForeignKey(fk => fk.MiningConcessionId);
            builder.HasOne(one => one.PeriodType).WithMany(many => many.Investments).HasForeignKey(fk => fk.PeriodTypeId);

        }
    }
}
