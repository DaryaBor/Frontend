using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAPI.Models;

namespace TodoAPI.Infrastructure.Data.SeanceModel.EntityConfigurations
{
    public class SeanceMap : IEntityTypeConfiguration<Seance>
    {
        public void Configure(EntityTypeBuilder<Seance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.DateSeance);

            builder.Property(x => x.Title);

            builder.Property(x => x.FilmId);

        }
    }
}
