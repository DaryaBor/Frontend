using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAPI.Models;

namespace TodoAPI.Infrastructure.Data.FilmModel.EntityConfigurations
{
    public class FilmMap : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Denomination);

            builder.Property(x => x.DateStart);

            builder.Property(x => x.Company);

        }
    }
}
