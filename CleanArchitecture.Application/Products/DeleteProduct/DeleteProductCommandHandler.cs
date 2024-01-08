using CleanArchitecture.Application.Products.CreateProduct;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Guid>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository) {
            _repository = repository;


        }

        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.FindByIdAsync(request.ProductId, cancellationToken);
            _repository.Remove(product);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;

        }
    }
}
