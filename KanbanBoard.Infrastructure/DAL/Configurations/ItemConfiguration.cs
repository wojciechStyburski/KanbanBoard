using KanbanBoard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KanbanBoard.Infrastructure.DAL.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");
        builder.Property(x => x.Description).HasMaxLength(150);
        builder.Property(x => x.State).IsRequired();
    }
}