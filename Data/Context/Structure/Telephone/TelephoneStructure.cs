using CustomerPanel.Domain.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerPanel.Data.Context.Structure
{
    public class TelephoneStructure : IEntityTypeConfiguration<Telephone>
    {
        public void Configure(EntityTypeBuilder<Telephone> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Id);

            entityTypeBuilder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            entityTypeBuilder.Property(e => e.ClientId).HasColumnName("ClientId");
            entityTypeBuilder.Property(e => e.DDD).HasColumnName("DDD");
            entityTypeBuilder.Property(e => e.Number).HasColumnName("Number");
            entityTypeBuilder.Property(e => e.TypeNumber).HasColumnName("TypeNumber");

            entityTypeBuilder.ToTable("Telephone");

        }
    }
}