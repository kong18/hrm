using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Products.UpdateOrder;
using CleanArchitecture.Domain.Common.Exceptions;
using CleanArchitecture.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.UpdateOrder
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _repository.FindByIdAsync(request.ProductId, cancellationToken);

            if (existingProduct == null)
            {
                // Handle the case where the product with the specified ID is not found
                // In this example, I'm throwing an exception, but you can customize this behavior
                throw new NotFoundException($"Product with ID {request.ProductId} not found.");
            }

            // Update the properties of the existing product
            existingProduct.Name = request.NewProductName;
            existingProduct.Price = request.NewPrice;
            // Update other properties as needed

            // Save the changes to the database
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            // Map the updated product to a ProductDto and return it
            return _mapper.Map<ProductDto>(existingProduct);
        }
    }
}
