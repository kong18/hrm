using CleanArchitecture.Application.Orders.CreateOrder;
using CleanArchitecture.Domain.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Products.CreateProduct
{
    public class CreateProductCommandValidator :AbstractValidator<CreateProductCommand>
    {

        private readonly IProductRepository _repository;
        public CreateProductCommandValidator(IProductRepository repository)
        {
            _repository = repository;

            ConfigureValidationRules();
        }


        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellationToken) => await _repository.FindByIdAsync(id, cancellationToken) == null)
                .WithMessage("Product with the same Id already exists.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}
