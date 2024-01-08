using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>>,IQuery
    {
        public GetProductsQuery(string Name)
        {
            this.Name = Name;

        }

        public string Name { get; set; }    
    }
}
