using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;


        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,

            };

            _repository.Add(product);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
