using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApi.Database.Entities;

namespace TestApi.Database.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<OrderEty>
    {
        public void Configure(EntityTypeBuilder<OrderEty> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
