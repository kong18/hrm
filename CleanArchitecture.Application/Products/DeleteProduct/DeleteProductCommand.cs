using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CleanArchitecture.Application.Products.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Guid>,ICommand
    {

        public Guid ProductId { get;}

        public DeleteProductCommand(Guid id)
        {
            ProductId = id;
        }



    }
    

}
