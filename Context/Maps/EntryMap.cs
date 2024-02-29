using Extratinhos.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Extratinhos.Context.Maps;

public class EntryMap : IEntityTypeConfiguration<Entry>
{
    public void Configure(EntityTypeBuilder<Entry> builder)
    {
        builder.ToTable(nameof(Entry));

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Description)
            .HasColumnType("text");

        builder.Property(e => e.CreatedAt)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasColumnType("timestamp")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.HasOne(e => e.Client)
            .WithMany(c => c.Entrys)
            .HasForeignKey(e => e.ClientId)
            .IsRequired();
    }
}
