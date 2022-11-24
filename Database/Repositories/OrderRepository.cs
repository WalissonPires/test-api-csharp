using Microsoft.EntityFrameworkCore;
using TestApi.Database.Entities;

namespace TestApi.Database.Repositories
{
    public class OrderRepository
    {
        private readonly AppDbContext _dbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<IEnumerable<OrderEty>> Find(FindOrderSepc spec)
        {
            var query = _dbContext.Orders.AsQueryable();

            if (spec.Id.HasValue)
                query = query.Where(x => x.Id == spec.Id);

            if (spec.CustomerId.HasValue)
                query = query.Where(x => x.CustomerId == spec.CustomerId);

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<OrderEty> Insert(OrderEty order)
        {
            var orderDb = new OrderEty
            {
                CustomerId = order.CustomerId,
                Amount = order.Amount,
                CreateAt = order.CreateAt,
                UpdatedAt = order.UpdatedAt,
                ClosedAt = order.ClosedAt,
                ReceivedAt = order.ReceivedAt
            };

            _dbContext.Orders.Add(orderDb);
            
            await _dbContext.SaveChangesAsync();

            return orderDb;
        }
    }

    public class FindOrderSepc
    {
        public int? Id { get; set; }
        public int? CustomerId { get; set; }
    }
}
