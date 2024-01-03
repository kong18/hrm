using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Repositories
{
    public interface IProductRepository : IEFRepository<Product, Product>
    {

        Task<Product?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Product>> FindByIdsAsync(Guid[] ids, CancellationToken cancellationToken = default);
    }
}
