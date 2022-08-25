using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TodoAPI.Models;

namespace TodoAPI.Infrastructure.Data.TicketsModel.EntityConfigurations
{
    public class TicketsMap : IEntityTypeConfiguration<Tickets>
    {
        public void Configure(EntityTypeBuilder<Tickets> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Number);

            builder.Property(x => x.SeanceNumber);

            builder.Property(x => x.Place);

            builder.Property(x => x.Cost);

            builder.Property(x => x.SeanceId);

        }
    }
}
