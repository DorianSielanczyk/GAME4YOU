using GAME4YOU.Data;
using GAME4YOU.Entities;
using Microsoft.EntityFrameworkCore;

public class OrderService
{
    private readonly Game4youDbContext _dbContext;

    public OrderService(Game4youDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Order>> GetOrdersByUserAsync(int userId)
    {
        return await _dbContext.Orders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }
}