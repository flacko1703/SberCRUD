using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;

namespace SberCrudOps.Infrastructure.EF.Configurations;

public class SberOperationInfoConfiguration : IEntityTypeConfiguration<SberOperationInfo>
{
    public void Configure(EntityTypeBuilder<SberOperationInfo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(c => c,
                value => new SberOperationInfoId(value))
            .ValueGeneratedOnAdd()
            .HasIdentityOptions(1)
            .HasColumnOrder(1);
        
        //Added Configuration
        builder.Property(so => so.AddedAtUtc)
            .HasConversion(c => c.Value,
                value => new AddedDateTimeNowUtc(value))
            .IsRequired()
            .HasColumnName("Added")
            .HasColumnOrder(2);
        
        //Deleted Configuration
        builder.Property(so => so.DeletedAtUtc)
            .HasConversion(c => c.Value,
                value => new DeletedDateTimeNowUtc(value))
            .HasColumnName("Deleted")
            .HasColumnOrder(3);
        
        builder.Property(so => so.InformationText)
            .HasConversion(c => c.Value,
                value => new Information(value))
            .HasColumnName("Information")
            .HasColumnOrder(4);
        
        builder.Property(x => x.Version)
            .IsRowVersion();

        builder.Ignore(x => x.CompletedAtUtc);
    }
}