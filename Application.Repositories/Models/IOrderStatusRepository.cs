using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application.Repositories
{
    public interface IOrderStatusRepository
    {
        Task<IEnumerable<OrderStatus>> GetAllAsync();
        Task<OrderStatus> GetByIdAsync(Guid id);
        Task CreateAsync(OrderStatus orderStatus);
        Task UpdateAsync(OrderStatus orderStatus);
        Task DeleteAsync(Guid id);
    }
}