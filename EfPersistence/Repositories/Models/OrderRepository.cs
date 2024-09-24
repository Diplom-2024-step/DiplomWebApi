using AnytourApi.Application.Repositories.Models;
using AnytourApi.Domain.Models.Enteties;
using AnytourApi.EfPersistence.Data;

namespace AnytourApi.EfPersistence.Repositories.Models;

public class OrderRepository(AppDbContext dbContext) : CrudRepository<Order>(dbContext), IOrderRepository;
