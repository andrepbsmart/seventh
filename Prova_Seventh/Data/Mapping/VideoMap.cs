using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Prova.Domain.Entities;

namespace Prova.Data.Mapping
{
    public class VideoMap : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("videos");

            builder.Property(video => video.idVideo)
                .HasColumnName("idvideo")
                .HasMaxLength(40);

            builder.Property(video => video.idServer)
                .HasColumnName("idserver")
                .HasMaxLength(40)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(video => video.Description)
                .HasColumnName("description")
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(video => video.Content)
                .HasColumnName("content")
                .HasMaxLength(8000)
                .HasColumnType("varchar")
                .IsRequired();

            builder.Property(video => video.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasKey(video => video.idVideo);

            builder.Ignore(x => x.Notification);
        }
    }
}
