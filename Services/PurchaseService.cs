using System;
using System.Threading.Tasks;
using GAME4YOU.Data;
using GAME4YOU.Entities;
using Microsoft.EntityFrameworkCore;

namespace GAME4YOU.Services
{
    public class PurchaseService
    {
        private readonly Game4youDbContext _context;

        public PurchaseService(Game4youDbContext context)
        {
            _context = context;
        }

        public async Task<bool> PurchaseProductAsync(int productId, string userEmail)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
                if (product == null || product.Quantity <= 0)
                {
                    return false;
                }

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                if (user == null)
                {
                    return false;
                }

                product.Quantity--;
                if (product.Quantity == 0)
                {
                    product.IsActive = false;
                }
                _context.Products.Update(product);
                var order = new Order
                {
                    CreatedAt = DateTime.UtcNow,
                    UserId = user.Id,
                    TotalAmount = 0m
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();  
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = 1,
                    Price = (decimal)product.Price
                };
                _context.OrderItems.Add(orderItem);

                order.TotalAmount = orderItem.Price * orderItem.Quantity;
                _context.Orders.Update(order);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> PurchaseCartAsync(IEnumerable<CartItem> cartItems, string userEmail)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
                if (user == null)
                    return false;

                var order = new Order
                {
                    CreatedAt = DateTime.UtcNow,
                    UserId = user.Id,
                    TotalAmount = 0m
                };
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                decimal totalAmount = 0m;

                foreach (var cartItem in cartItems)
                {
                    var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == cartItem.Product.Id);
                    if (product == null || product.Quantity < cartItem.Quantity)
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }

                    product.Quantity -= cartItem.Quantity;
                    if (product.Quantity == 0)
                        product.IsActive = false;

                    _context.Products.Update(product);

                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = cartItem.Quantity,
                        Price = (decimal)product.Price
                    };
                    _context.OrderItems.Add(orderItem);

                    totalAmount += orderItem.Price * orderItem.Quantity;
                }

                order.TotalAmount = totalAmount;
                _context.Orders.Update(order);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
