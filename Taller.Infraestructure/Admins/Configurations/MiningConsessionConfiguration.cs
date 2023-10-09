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
    public class MiningConsessionConfiguration : IEntityTypeConfiguration<MiningConcession>
    {
        public void Configure(EntityTypeBuilder<MiningConcession> builder)
        {
            builder.ToTable("miningconcession", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.MineralTypeId).HasColumnName("mineraltypeid");
            builder.Property(t => t.OriginId).HasColumnName("originid");
            builder.Property(t => t.TypeId).HasColumnName("typeid");
            builder.Property(t => t.SituationId).HasColumnName("situationid");
            builder.Property(t => t.MiningunitId).HasColumnName("miningunitId");
            builder.Property(t => t.ConditionId).HasColumnName("conditionid");
            builder.Property(t => t.StatemanagementId).HasColumnName("statemanagementid");
            builder.Property(t => t.Issincronized).HasColumnName("issincronized");
            builder.Property(t => t.RegistrationDate)
                 .HasColumnName("registrationdate")
                 .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}
