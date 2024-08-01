using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MK.QRMenu.Domain.Entities;

namespace MK.QRMenu.Infrastructure.Configurations
{
    internal sealed class KampanyaConfiguration : IEntityTypeConfiguration<Kampanya>
    {
        public void Configure(EntityTypeBuilder<Kampanya> builder)
        {
            builder.Property(x => x.Title).HasColumnType("varchar(200)");
            builder.Property(x => x.Description).HasColumnType("varchar(500)");
            builder.Property(x => x.ImageUrl).HasColumnType("varchar(max)");
            builder.Property(x => x.LinkUrl).HasColumnType("varchar(max)");
        }
    }
}
