using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace EfPersistence
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly AnytourDbContext _dbContext;

        public OrderStatusRepository(AnytourDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<OrderStatus>> GetAllAsync()
        {
            return await _dbContext.OrderStatuses.ToListAsync();
        }

        public async Task<OrderStatus> GetByIdAsync(Guid id)
        {
            return await _dbContext.OrderStatuses.FindAsync(id);
        }

        public async Task CreateAsync(OrderStatus orderStatus)
        {
            await _dbContext.OrderStatuses.AddAsync(orderStatus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderStatus orderStatus)
        {
            _dbContext.OrderStatuses.Update(orderStatus);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var orderStatus = await _dbContext.OrderStatuses.FindAsync(id);
            _dbContext.OrderStatuses.Remove(orderStatus);
            await _dbContext.SaveChangesAsync();
        }
    }
}