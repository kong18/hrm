using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.UpdateOrder
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId must not be empty.");

            RuleFor(x => x.NewProductName).NotEmpty().WithMessage("NewProductName must not be empty.");

            RuleFor(x => x.NewPrice).GreaterThan(0).WithMessage("NewPrice must be greater than 0.");
        }

    }
}
