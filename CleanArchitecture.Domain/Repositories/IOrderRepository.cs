using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IOrderRepository : IEFRepository<Order, Order>
    {
        
        Task<Order?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        
        Task<List<Order>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}
