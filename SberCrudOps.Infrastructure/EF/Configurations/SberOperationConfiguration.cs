using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SberCrudOps.Application.Extensions;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.Entities;
using SberCrudOps.Domain.Aggregates.SberOperationAggregate.ValueObjects;
using SberCrudOps.Domain.Enumerations;
using SberCrudOps.Infrastructure.EF.Consts;

namespace SberCrudOps.Infrastructure.EF.Configurations;

public class SberOperationConfiguration : IEntityTypeConfiguration<SberOperation>
{
    public void Configure(EntityTypeBuilder<SberOperation> builder)
    {
        builder.ToTable(DbTableNames.SberOperationTable);

        //Id Configuration
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .IsRequired()
            .HasConversion(c => c,
                value => new SberOperationId(value))
            .ValueGeneratedOnAdd()
            .HasIdentityOptions(1)
            .HasColumnOrder(1);

        //SberOperationInfo Configuration
        builder.HasOne(typeof(SberOperationInfo), "_sberOperationInfo")
            .WithOne()
            .HasForeignKey(typeof(SberOperation), "IdSource")
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property("IdSource")
            .HasColumnOrder(2);
        
        //Information Configuration
        builder.Property(so => so.InformationText)
            .HasConversion(c => c.Value,
                value => new Information(value))
            .HasColumnName("Information")
            .HasColumnOrder(3);

        //Added Configuration
        builder.Property(so => so.AddedAtUtc)
            .HasConversion(c => c.Value,
                value => new AddedDateTimeNowUtc(value))
            .IsRequired()
            .HasColumnName("Added")
            .HasColumnOrder(4);
        
        //Deleted Configuration
        builder.Ignore(so => so.DeletedAtUtc);
        
        //TypeWork Configuration
        var typeWorkConversion = new ValueConverter<TypeWork, int>(tw
                => tw.Value,
            value => TypeWork.FromValue(value));
        
        builder.Property(typeof(TypeWork), "_typeWork")
            .IsRequired()
            .HasConversion(typeWorkConversion)
            .HasColumnName("TypeWork")
            .HasColumnOrder(5);
        
        //Completed Configuration
        builder.Property(so => so.CompletedAtUtc)
            .HasConversion(c => c.Value.Value.Truncate(TimeSpan.TicksPerMillisecond),
                value => new CompletedDateTimeNowUtc(value))
            .HasColumnName("Completed")
            .HasColumnOrder(6);

        builder.Property(x => x.Version)
            .IsRowVersion();

    }
}