using GraphQLDemo.DAL.Configuration.DataType;
using GraphQLDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLDemo.DAL.Configuration
{
    public class StatisticsConfig : IEntityTypeConfiguration<Statistics>
    {
        public const string Table_name = "statistics";

        public void Configure(EntityTypeBuilder<Statistics> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => new { e.Id });

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid)
                   .HasColumnName("pk_statistics_id");

            builder.Property(e => e.LastActive)
                   .HasColumnName("last_active");

            builder.Property(e => e.rating)
                .HasColumnType(EntityDataTypes.Double)
                .HasColumnName("rating");

            builder.Property(e => e.Age)
                .HasColumnType(EntityDataTypes.Smallint)
                .HasColumnName("age");
        }
    }
}
