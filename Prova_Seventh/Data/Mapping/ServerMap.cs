using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Prova.Domain.Entities;

namespace Prova.Data.Mapping
{
    public class ServerMap : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.ToTable("servers");

            builder.HasKey(server => server.idServer);

            builder.Property(server => server.idServer)
                .HasColumnName("idserver")
                .HasMaxLength(40);

            builder.Property(server => server.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(server => server.IP)
                .HasColumnName("ip")
                .HasMaxLength(20)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(server => server.Port)
                .HasColumnName("port")
                .HasColumnType("int")
                .IsRequired();

            //builder.OwnsOne(x => x.IP)
            //    .Property(x => x.Value)
            //    .HasColumnName("ip")
            //    .IsRequired();

            builder.Property(server => server.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("datetime")
                .IsRequired();
           
            builder.Ignore(x => x.Notification);
        }
    }
}
