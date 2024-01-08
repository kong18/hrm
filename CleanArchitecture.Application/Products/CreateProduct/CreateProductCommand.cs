using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.CreateProduct
{
    public class CreateProductCommand : IRequest<Guid>, ICommand
    {

        public CreateProductCommand(Guid id,string name, decimal price)
        {
            Name = name;
            Id = id;
            Price = price;
        }


        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
