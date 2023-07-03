using CustomerPanel.Domain.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerPanel.Data.Context.Structure
{
    public class ClientStructure : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(e => e.Id);

            entityTypeBuilder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            entityTypeBuilder.Property(e => e.LegalName).HasColumnName("LegalName");
            entityTypeBuilder.Property(e => e.Mail).HasColumnName("Mail");

            entityTypeBuilder.ToTable("Client");

        }
    }
}