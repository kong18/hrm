using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.UpdateOrder
{
    public class UpdateProductCommand : IRequest<ProductDto>, ICommand
    {
        public Guid ProductId { get; set; }
        public string NewProductName { get; set; } // Corrected property name
        public decimal NewPrice { get; set; }

        public UpdateProductCommand(Guid productId, string newProductName, decimal newPrice)
        {
            ProductId = productId;
            NewProductName = newProductName;
            NewPrice = newPrice;
        }
    }
}
