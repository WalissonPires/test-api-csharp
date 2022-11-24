using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApi.Database.Entities;

namespace TestApi.Database.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<CustomerEty>
    {
        public void Configure(EntityTypeBuilder<CustomerEty> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200);
        }
    }
}
